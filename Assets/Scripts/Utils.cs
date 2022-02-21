using System.IO;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine;
public class JsonReader {
    private string passedString;
    public string Read (string route) {
        string filePath = Path.Combine(Application.streamingAssetsPath + Path.DirectorySeparatorChar, route);
        string jsonString = "";

        Debug.Log ("UNITY:" + System.Environment.NewLine + filePath);

        if (filePath.Contains ("://") || filePath.Contains (":///")) {
            ReadFromAndroid(filePath);
            jsonString = passedString;
        } else {
            jsonString = File.ReadAllText(filePath);
        }

        return(jsonString);
    }

    public IEnumerable ReadFromAndroid (string filePath) {
        UnityWebRequest www = UnityWebRequest.Get(filePath);       
        yield return www.SendWebRequest();
		passedString = www.downloadHandler.text;
        Debug.Log("JSON DATA::: " + passedString);
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