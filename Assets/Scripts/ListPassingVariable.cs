using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ListPassingVariable : MonoBehaviour
{
    public int letterNumber;
    public int score;

    void Start()
    {
        score = PlayerPrefs.GetInt("LetterScore", 0);
    }

    public void LoadListToLetter()
    {      
        if (score > letterNumber)
        {
            PlayerPrefs.SetInt("listIndex", letterNumber);
            SceneManager.LoadScene("Hijaiyah Level");
            Debug.Log("indexList " + letterNumber);
        }

        else if (score <= letterNumber)
        {
            PlayerPrefs.SetInt("listIndex", score);
            SceneManager.LoadScene("Hijaiyah Level");
            Debug.Log("indexList " + letterNumber);
        }

    }    
}
