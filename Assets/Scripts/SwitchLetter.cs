using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SwitchLetter : MonoBehaviour
{

    public GameObject[] hijaiyahLetter;
    public GameObject[] hijaiyahTitleText; 
    public AudioSource[] hijaiyahLetterSound;
    public GameObject[] letterNavigationBtn;
    public GameObject[] prefabLetter;

    int indexLetter;

    void Start()
    {
        indexLetter = 0;
        hijaiyahLetter[0].gameObject.SetActive(true);
        hijaiyahTitleText[0].gameObject.SetActive(true);
    }

    void UpdateLetter()
    {
        if (indexLetter >= 3)
        {
            indexLetter = 3;
        }    

        if (indexLetter <= 0)
        {
            indexLetter = 0; 
        }    
                            
    }
    

    public void NextLetter()
    {
        indexLetter++;

        for (int i = 0; i < hijaiyahLetter.Length; i++)
        {
            hijaiyahLetter[i].gameObject.SetActive(false);
            hijaiyahTitleText[i].gameObject.SetActive(false);

            hijaiyahLetter[indexLetter].gameObject.SetActive(true);
            hijaiyahTitleText[indexLetter].gameObject.SetActive(true);
            
        }

        if (indexLetter == 3)
        {
            letterNavigationBtn[0].gameObject.SetActive(true);
            letterNavigationBtn[1].gameObject.SetActive(false);
        }      
        
        else if (indexLetter > 0 && indexLetter < 3)
        {
            letterNavigationBtn[0].gameObject.SetActive(true);
            letterNavigationBtn[1].gameObject.SetActive(true); 
        }

        Debug.Log(indexLetter);
    }

    public void PreviousLetter()
    {
        indexLetter--;

        for (int i = 0; i < hijaiyahLetter.Length; i++)
        {
            hijaiyahLetter[i].gameObject.SetActive(false);
            hijaiyahTitleText[i].gameObject.SetActive(false);

            hijaiyahLetter[indexLetter].gameObject.SetActive(true); 
            hijaiyahTitleText[indexLetter].gameObject.SetActive(true);
        }

        if (indexLetter == 0)
        {
            letterNavigationBtn[0].gameObject.SetActive(false);
            letterNavigationBtn[1].gameObject.SetActive(true);
        }

        else if (indexLetter > 0 && indexLetter < 3)
        {
            letterNavigationBtn[0].gameObject.SetActive(true);
            letterNavigationBtn[1].gameObject.SetActive(true); 
        }

        Debug.Log(indexLetter);
    }

    public void hijaiyahLetterRecitation()
    {
        for(int i = 0; i< hijaiyahLetter.Length; i++)
        {
            hijaiyahLetterSound[i].gameObject.SetActive(false);
            hijaiyahLetterSound[indexLetter].gameObject.SetActive(true);
        }

        hijaiyahLetterSound[indexLetter].Play();

    }

    public void RestartOnClick()
    {
        Destroy (hijaiyahLetter[indexLetter]);
        hijaiyahLetter[indexLetter] = Instantiate (prefabLetter[indexLetter]);
        hijaiyahLetter[indexLetter].gameObject.SetActive(true);
    }

}
