using UnityEngine;

[System.Serializable]
public class LevelData {
    public int[] levelScores;
    public int gameProgress;

    public LevelData (LevelManager level) {
        levelScores = level.levelScores;
        gameProgress = level.gameProgress;
    }
}
