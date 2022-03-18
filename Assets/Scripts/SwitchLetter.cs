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
    public GameObject[] hijaiyahLetterVideoObject;
    public GameObject[] letterNavigationBtn;
    public GameObject[] prefabLetter;
    public VideoPlayer[] recitationLetterVideo;
    public GameObject[] dialogueBox;




    public int indexLetter;
    int indexPrevious;
    public int currentScore;

    void Start()
    {   
        currentScore = PlayerPrefs.GetInt("LetterScore", 0);

        indexLetter = PlayerPrefs.GetInt("listIndex", 0);
        
        hijaiyahLetter[indexLetter].gameObject.SetActive(true);
        hijaiyahTitleText[indexLetter].gameObject.SetActive(true);

        if (indexLetter == 0)
        {
            letterNavigationBtn[0].gameObject.SetActive(false);
            letterNavigationBtn[1].gameObject.SetActive(true);
        }

        else if (indexLetter == 27)
        {
            letterNavigationBtn[0].gameObject.SetActive(true);
            letterNavigationBtn[1].gameObject.SetActive(false);
        }   

        else if (indexLetter > 0 && indexLetter < 27)
        {
            letterNavigationBtn[0].gameObject.SetActive(true);
            letterNavigationBtn[1].gameObject.SetActive(true); 
        }        



    }

    void Update()
    {
        currentScore = PlayerPrefs.GetInt("LetterScore", 0);

        // To reset index intialization at each frame so it wont get ahead or too low.
        if (indexLetter >= 27)
        {
            indexLetter = 27;
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

        if (indexLetter == 27)
        {
            letterNavigationBtn[0].gameObject.SetActive(true);
            letterNavigationBtn[1].gameObject.SetActive(false);
        }      
        
        else if (indexLetter > 0 && indexLetter < 27)
        {
            letterNavigationBtn[0].gameObject.SetActive(true);
            letterNavigationBtn[1].gameObject.SetActive(true); 
        }

        indexPrevious = indexLetter - 1;

        hijaiyahLetterVideoObject[indexPrevious].gameObject.SetActive(false);
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

        else if (indexLetter > 0 && indexLetter < 27)
        {
            letterNavigationBtn[0].gameObject.SetActive(true);
            letterNavigationBtn[1].gameObject.SetActive(true); 
        }

        indexPrevious = indexLetter + 1;

        hijaiyahLetterVideoObject[indexPrevious].gameObject.SetActive(false);

        Debug.Log(indexLetter);
    }

    public void hijaiyahLetterRecitation()
    {
        for(int i = 0; i< hijaiyahLetter.Length; i++)
        {
            hijaiyahLetterVideoObject[i].gameObject.SetActive(false);
            hijaiyahLetterVideoObject[indexLetter].gameObject.SetActive(true);
            
            hijaiyahLetter[indexLetter].gameObject.SetActive(false);
        }

    }

    public void closeRecitationLetterOnClick()
    {
        hijaiyahLetterVideoObject[indexLetter].gameObject.SetActive(false);
            
        hijaiyahLetter[indexLetter].gameObject.SetActive(true);
    }

    public void playRecitationLetterOnClick()
    {
        recitationLetterVideo[indexLetter].Play();
    }

    public void RestartOnClick()
    {
        if (currentScore > indexLetter)
        {
            Destroy (hijaiyahLetter[indexLetter]);
            hijaiyahLetter[indexLetter] = Instantiate (prefabLetter[indexLetter]);
            hijaiyahLetter[indexLetter].gameObject.SetActive(true);

            hijaiyahLetterVideoObject[indexLetter].gameObject.SetActive(false);
        }
    }

    public void dialogueBoxOnClick ()
    {

        dialogueBox[0].gameObject.SetActive(false);
        dialogueBox[1].gameObject.SetActive(false);
        dialogueBox[2].gameObject.SetActive(false);
        dialogueBox[3].gameObject.SetActive(false);
        dialogueBox[4].gameObject.SetActive(false);
    }

    public void letterToListOnClick()
    {   
        // Level One
        if (indexLetter >= 0 & indexLetter < 4)
        {
            // To set level upon exiting to List Menu
            int indexLvlLetter = 0;
            PlayerPrefs.SetInt("IndexLvlLetter", indexLvlLetter);
        }

        // Level Two
        else if (indexLetter > 3 & indexLetter < 7)
        {
            // To set level upon exiting to List Menu
            int indexLvlLetter = 1;
            PlayerPrefs.SetInt("IndexLvlLetter", indexLvlLetter);
        }

        // Level Three
        else if (indexLetter > 6 & indexLetter < 11)
        {
            // To set level upon exiting to List Menu
            int indexLvlLetter = 2;
            PlayerPrefs.SetInt("IndexLvlLetter", indexLvlLetter);
        }

        // Level Four
        else if (indexLetter > 10 & indexLetter < 15)
        {
            // To set level upon exiting to List Menu
            int indexLvlLetter = 3;
            PlayerPrefs.SetInt("IndexLvlLetter", indexLvlLetter);
        }

        // Level Five
        if (indexLetter > 14  & indexLetter < 19)
        {
            // To set level upon exiting to List Menu
            int indexLvlLetter = 4;
            PlayerPrefs.SetInt("IndexLvlLetter", indexLvlLetter);
        }

        // Level Six
        else if (indexLetter > 18 & indexLetter < 23)
        {
            // To set level upon exiting to List Menu
            int indexLvlLetter = 5;
            PlayerPrefs.SetInt("IndexLvlLetter", indexLvlLetter);
        }

        // Level Seven
        else if (indexLetter > 22 & indexLetter < 27)
        {
            // To set level upon exiting to List Menu
            int indexLvlLetter = 6;
            PlayerPrefs.SetInt("IndexLvlLetter", indexLvlLetter);
        }

        // Level Eight
        else if (indexLetter > 26 & indexLetter < 28)
        {
            // To set level upon exiting to List Menu
            int indexLvlLetter = 7;
            PlayerPrefs.SetInt("IndexLvlLetter", indexLvlLetter);
        }

        SceneManager.LoadScene("Hijaiyah_List");
    }
    
        void OnDestroy()
    {
        //This will happen whenever this object is destroyed, which includes scene changes
        // as well as existing the programs.
        Debug.Log ("Scene Object was destroyed.");

        indexLetter = 0;
        PlayerPrefs.SetInt("listIndex", indexLetter);
        Debug.Log("Your last index " + indexLetter );
                
    }
}
