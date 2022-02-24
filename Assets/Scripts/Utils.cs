using System.IO;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine;
public class JsonReader {
    public string Read (string route) {
        string filePath = Path.Combine(Application.streamingAssetsPath + Path.DirectorySeparatorChar, route);
        string jsonString = "";

        Debug.Log ("UNITY:" + System.Environment.NewLine + filePath);

        #if  UNITY_EDITOR || UNITY_IOS
        jsonString = File.ReadAllText (filePath);
 
        #elif UNITY_ANDROID
        WWW reader = new WWW (filePath);
        while (!reader.isDone) {
        }
        jsonString = reader.text;
        #endif
 
        // LocalizationData loadedData = JsonUtility.FromJson<LocalizationData> (jsonString);
 
        // for (int i = 0; i < loadedData.items.Length; i++) {
        //     localizedTextDictionary.Add (loadedData.items [i].key, loadedData.items [i].value);
        // }
        Debug.Log ("Data loaded, dictionary contains: " + jsonString);

        return(jsonString);
    }

    public string GetUsername () {
        return(PlayerPrefs.GetString("username","Jompot"));
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