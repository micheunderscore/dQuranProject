using System.IO;
using UnityEngine;

[System.Serializable]
public class LevelManager : MonoBehaviour {
    public int[] levelProgress = new int[32];
    public GameObject[] pages;

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

        int layer = 0;
        foreach (GameObject page in pages){
            Transform panel = page.transform.Find("LevelPanel");
            for (int i = 1; i <= 10; i++) {
                panel.transform.Find("LevelButton" + i).gameObject.GetComponentInChildren<Star>().score = levelProgress[i + layer];
            }
            layer += 10;
        }
    }

    public void OnDestroy() {
        SaveSystem.SaveLevels(this);
    }
}