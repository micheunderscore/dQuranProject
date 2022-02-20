using System.IO;
using UnityEngine;

[System.Serializable]
public class LevelManager : MonoBehaviour {
    public int[] levelProgress = new int[32];
    public Transform pages;

    public void Awake() {
        if (SaveSystem.CrossSceneInformation == null) SaveSystem.CrossSceneInformation = new int[32];
        if (!File.Exists(Application.persistentDataPath + "/player.dq")) return;
        LevelData data = SaveSystem.LoadLevel();
        levelProgress = data.levelProgress;
    }

    public void Start() {
        int[] passedData = SaveSystem.CrossSceneInformation;
        print(passedData[0]);
        for (int i = 0; i < passedData.Length; i++) {
            print(passedData[i]);
            if (passedData[i] > levelProgress[i]) {
                levelProgress[i] = passedData[i];
            }
        }
        int count = 1;
        // Load progress on pages
        foreach (Transform page in pages){
            foreach (Transform child in page.transform.Find("LevelPanel")) {
                child.gameObject.GetComponentInChildren<Star>().score = levelProgress[count];
                count += 1;
            }
        }
    }

    public void OnDestroy() {
        SaveSystem.SaveLevels(this);
    }
}