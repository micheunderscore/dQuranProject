using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem {
    public static int[] CrossSceneInformation { get; set; }

    public static void SaveLevels (LevelManager level) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.dq";
        FileStream stream = new FileStream(path, FileMode.Create);

        LevelData data = new LevelData(level);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static LevelData LoadLevel () {
        string path = Application.persistentDataPath + "/player.dq";
        if(File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LevelData data = formatter.Deserialize(stream) as LevelData;
            stream.Close();
            
            return data;
        } else {
            UnityEngine.Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}