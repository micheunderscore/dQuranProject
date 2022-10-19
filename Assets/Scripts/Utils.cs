using System.IO;
using UnityEngine;

public class JsonReader {
    public string Read(string route) {
        string filePath = Path.Combine(Application.streamingAssetsPath + Path.DirectorySeparatorChar, route);
        string jsonString = "";

        Debug.Log("UNITY:" + System.Environment.NewLine + filePath);

#if UNITY_EDITOR || UNITY_IOS
        jsonString = File.ReadAllText(filePath);

#elif UNITY_ANDROID
        WWW reader = new WWW (filePath);
        while (!reader.isDone) {
        }
        jsonString = reader.text;
#endif

        // Debug.Log ("Data loaded, dictionary contains: " + jsonString);

        return (jsonString);
    }

    public string GetUsername() {
        return (PlayerPrefs.GetString("username", "Mel"));
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