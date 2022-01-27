using System.IO;
using UnityEngine;
public class JsonReader {
    public string Read (string route) {
        string path = Application.dataPath + route;
        string jsonString = File.ReadAllText(path);
        return(jsonString);
    }

    public string GetUsername () {
        return(JsonUtility.FromJson<UserSave>(Read("/Saves/userdata.json")).username);
    }
}

// Class type declarations. Globally accessible.

public class UserSave {
    public string username;
    public UserProgress[] progress;
}

public class UserProgress {
    public string mode;
    public int level;
}