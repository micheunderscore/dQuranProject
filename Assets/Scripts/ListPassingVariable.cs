using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ListPassingVariable : MonoBehaviour
{
    public int letterNumber;

    public void LoadListToLetter()
    {    
        PlayerPrefs.SetInt("listIndex", letterNumber);
        SceneManager.LoadScene("Hijaiyah Level");
        Debug.Log("indexList " + letterNumber);
    }    
}
