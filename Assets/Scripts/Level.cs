using UnityEngine;

[System.Serializable]
public class LevelData {
    public int[] levelProgress;

    public LevelData (LevelManager level) {
        levelProgress = level.levelProgress;
    }
}
