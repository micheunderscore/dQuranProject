using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    
    public int menuIndex;
    
    void Start()
    {
        menuIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("IndexLvlLetter", menuIndex);
    }

    public void menuToSceneModule(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
