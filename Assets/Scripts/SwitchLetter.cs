using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class SwitchLetter : MonoBehaviour
{

    public GameObject[] hijaiyahLetter;
    public GameObject[] hijaiyahTitleText; 
    public GameObject[] hijaiyahLetterSound;
    public GameObject[] letterNavigationBtn;
    public GameObject[] prefabLetter;
    public VideoPlayer[] recitationLetterVideo;
    public GameObject[] progressDialogueBox;
    public GameObject[] progressStarLetter;

    int indexLetter;
    int indexPrevious;
    public int newIndexTrigger = 0;

    void Start()
    {   
        indexLetter = 0;
        hijaiyahLetter[0].gameObject.SetActive(true);
        hijaiyahTitleText[0].gameObject.SetActive(true);
    }

    void Update()
    {

        
        // To reset index intialization at each frame so it wont get ahead or too low.
        if (indexLetter >= 3)
        {
            indexLetter = 3;
        }    

        if (indexLetter <= 0)
        {
            indexLetter = 0; 
        }        

        //Update score on load
        //Have user attempt the exercise before?
        if (newIndexTrigger > indexLetter)
        {                
            // To set star object as active
            // Level 1
            if(newIndexTrigger < 5)
            {
                for(int i = 0; i < newIndexTrigger; i++)
                {
                progressStarLetter[i].gameObject.SetActive(true);
                }  
            }

            // Level 2
            else if(newIndexTrigger > 4 && newIndexTrigger < 8)
            {   
                // Turning off level 1 star
                for(int y = 0; y <= 4; y++)
                {
                    progressStarLetter[y].gameObject.SetActive(false);
                }
                // Turning on level 2 star
                for(int z = 4; z < newIndexTrigger; z++)
                {
                    progressStarLetter[z].gameObject.SetActive(true);
                }
            }       
        }
    }

    void OnDestroy()
    {
        //This will happen whenever this object is destroyed, which includes scene changes
        // as well as existing the programs.
        Debug.Log ("Scene Object was destroyed.");

        PlayerPrefs.SetInt("LetterScore", newIndexTrigger);
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

        indexPrevious = indexLetter - 1;

        hijaiyahLetterSound[indexPrevious].gameObject.SetActive(false);

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

        indexPrevious = indexLetter + 1;

        hijaiyahLetterSound[indexPrevious].gameObject.SetActive(false);

        Debug.Log(indexLetter);
    }

    public void hijaiyahLetterRecitation()
    {
        for(int i = 0; i< hijaiyahLetter.Length; i++)
        {
            hijaiyahLetterSound[i].gameObject.SetActive(false);
            hijaiyahLetterSound[indexLetter].gameObject.SetActive(true);
            
            hijaiyahLetter[indexLetter].gameObject.SetActive(false);
        }

    }

    public void closeRecitationLetterOnClick()
    {
        hijaiyahLetterSound[indexLetter].gameObject.SetActive(false);
            
        hijaiyahLetter[indexLetter].gameObject.SetActive(true);
    }

    public void playRecitationLetterOnClick()
    {
        recitationLetterVideo[indexLetter].Play();
    }

    public void RestartOnClick()
    {
        Destroy (hijaiyahLetter[indexLetter]);
        hijaiyahLetter[indexLetter] = Instantiate (prefabLetter[indexLetter]);
        hijaiyahLetter[indexLetter].gameObject.SetActive(true);

        hijaiyahLetterSound[indexLetter].gameObject.SetActive(false);

    }

    public void OnTriggerEnter2D (Collider2D collider)
    {   
        //Load data from player prefs.
        newIndexTrigger = PlayerPrefs.GetInt("LetterScore", 0);

        // To check if user is attempting for first time    
        if (newIndexTrigger == indexLetter)
        {
            progressDialogueBox[newIndexTrigger].gameObject.SetActive(true);    
            
            // To set star object as active
            // Level 1
            if(newIndexTrigger < 5)
            {
                for(int i = 0; i < newIndexTrigger; i++)
                {
                progressStarLetter[i].gameObject.SetActive(true);
                }  
            }

            // Level 2
            else if(newIndexTrigger > 4 && newIndexTrigger < 8)
            {   
                // Turning off level 1 star
                for(int y = 0; y <= 4; y++)
                {
                    progressStarLetter[y].gameObject.SetActive(false);
                }
                // Turning on level 2 star
                for(int z = 4; z < newIndexTrigger; z++)
                {
                    progressStarLetter[z].gameObject.SetActive(true);
                }
            }         
        }

        newIndexTrigger++;
        PlayerPrefs.SetInt("LetterScore", newIndexTrigger);
        Debug.Log("Trigger!");
    }
}
