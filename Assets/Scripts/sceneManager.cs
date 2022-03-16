using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    private int sceneToContinue;
    private int currrentSceneIndex;

    void Start()
    {
        sceneToContinue = PlayerPrefs.GetInt("SavedScene");
        Debug.Log("Your last scene is " + sceneToContinue);
    }

    public void LoadToScene (string sceneName) 
    {  
        currrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currrentSceneIndex);
        Debug.Log("Your scene is " + currrentSceneIndex);

        SceneManager.LoadScene(sceneName);
    }

    public void ContinueScene()
    {
        if (sceneToContinue != 0)
            SceneManager.LoadScene(sceneToContinue);

        else
            return;
    }

    public void ExitDQuran()
    {
        Application.Quit();
        Debug.Log("Go Away!");
    }
}
