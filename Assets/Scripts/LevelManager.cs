using System.IO;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class LevelManager : MonoBehaviour {
    public int[] levelScores = new int[32];
    public int gameProgress = 1;
    public Transform pages;

    public void Awake() {
        if (SaveSystem.CrossSceneInformation == null) SaveSystem.CrossSceneInformation = new int[32];
        if (SaveSystem.PassedGameProgress == 0) SaveSystem.PassedGameProgress = 1;
        if (!File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "player.dq")) return;
        LevelData data = SaveSystem.LoadLevel();
        levelScores = data.levelScores;
        gameProgress = data.gameProgress;
    }

    public void Start() {
        int[] passedData = SaveSystem.CrossSceneInformation;
        if (gameProgress < SaveSystem.PassedGameProgress) {
            gameProgress = SaveSystem.PassedGameProgress;
        }
        for (int i = 0; i < passedData.Length; i++) {
            print(passedData[i]);
            if (passedData[i] > levelScores[i]) {
                levelScores[i] = passedData[i];
            }
        }
        int count = 1;
        // Load progress on pages
        foreach (Transform page in pages){
            foreach (Transform child in page.transform.Find("LevelPanel")) {
                child.gameObject.GetComponentInChildren<Star>().score = levelScores[count];
                child.gameObject.GetComponent<Button>().interactable = count <= gameProgress;
                count += 1;
            }
        }
    }

    public void OnDestroy() {
        SaveSystem.SaveLevels(this);
    }

}