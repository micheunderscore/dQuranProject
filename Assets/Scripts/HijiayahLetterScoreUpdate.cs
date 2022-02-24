using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HijiayahLetterScoreUpdate : MonoBehaviour
{
    public GameObject[] progressDialogueBox;
    public GameObject[] progressStarLetter;

    public int indexScoreLetter = 0;
    public int currentPage;


    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.Find("Switch");
        SwitchLetter sL = go.GetComponent<SwitchLetter>();

        indexScoreLetter = PlayerPrefs.GetInt("LetterScore", 0);
        currentPage = sL.indexLetter;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Find("Switch");
        SwitchLetter sL = go.GetComponent<SwitchLetter>();

        currentPage = sL.indexLetter;


        //Update score on load
        // To set start object as active
        // Level 1
        switch (indexScoreLetter)
        {
            case 15:
                progressStarLetter[14].gameObject.SetActive(true);
                progressStarLetter[13].gameObject.SetActive(true);
                progressStarLetter[12].gameObject.SetActive(true);
                progressStarLetter[11].gameObject.SetActive(true);

                progressStarLetter[10].gameObject.SetActive(false);
                progressStarLetter[9].gameObject.SetActive(false);
                progressStarLetter[8].gameObject.SetActive(false);
                progressStarLetter[7].gameObject.SetActive(false);

                progressStarLetter[6].gameObject.SetActive(false);
                progressStarLetter[5].gameObject.SetActive(false);
                progressStarLetter[4].gameObject.SetActive(false);

                progressStarLetter[3].gameObject.SetActive(false);
                progressStarLetter[2].gameObject.SetActive(false);
                progressStarLetter[1].gameObject.SetActive(false);
                progressStarLetter[0].gameObject.SetActive(false);

                break; 

            case 14:
                progressStarLetter[14].gameObject.SetActive(false);
                progressStarLetter[13].gameObject.SetActive(true);
                progressStarLetter[12].gameObject.SetActive(true);
                progressStarLetter[11].gameObject.SetActive(true);

                progressStarLetter[10].gameObject.SetActive(false);
                progressStarLetter[9].gameObject.SetActive(false);
                progressStarLetter[8].gameObject.SetActive(false);
                progressStarLetter[7].gameObject.SetActive(false);

                progressStarLetter[6].gameObject.SetActive(false);
                progressStarLetter[5].gameObject.SetActive(false);
                progressStarLetter[4].gameObject.SetActive(false);

                progressStarLetter[3].gameObject.SetActive(false);
                progressStarLetter[2].gameObject.SetActive(false);
                progressStarLetter[1].gameObject.SetActive(false);
                progressStarLetter[0].gameObject.SetActive(false);

                break;

            case 13:
                progressStarLetter[14].gameObject.SetActive(false);
                progressStarLetter[13].gameObject.SetActive(false);
                progressStarLetter[12].gameObject.SetActive(true);
                progressStarLetter[11].gameObject.SetActive(true);

                progressStarLetter[10].gameObject.SetActive(false);
                progressStarLetter[9].gameObject.SetActive(false);
                progressStarLetter[8].gameObject.SetActive(false);
                progressStarLetter[7].gameObject.SetActive(false);

                progressStarLetter[6].gameObject.SetActive(false);
                progressStarLetter[5].gameObject.SetActive(false);
                progressStarLetter[4].gameObject.SetActive(false);

                progressStarLetter[3].gameObject.SetActive(false);
                progressStarLetter[2].gameObject.SetActive(false);
                progressStarLetter[1].gameObject.SetActive(false);
                progressStarLetter[0].gameObject.SetActive(false);

                break;

            case 12:
                progressStarLetter[14].gameObject.SetActive(false);
                progressStarLetter[13].gameObject.SetActive(false);
                progressStarLetter[12].gameObject.SetActive(false);
                progressStarLetter[11].gameObject.SetActive(true);

                progressStarLetter[10].gameObject.SetActive(false);
                progressStarLetter[9].gameObject.SetActive(false);
                progressStarLetter[8].gameObject.SetActive(false);
                progressStarLetter[7].gameObject.SetActive(false);

                progressStarLetter[6].gameObject.SetActive(false);
                progressStarLetter[5].gameObject.SetActive(false);
                progressStarLetter[4].gameObject.SetActive(false);

                progressStarLetter[3].gameObject.SetActive(false);
                progressStarLetter[2].gameObject.SetActive(false);
                progressStarLetter[1].gameObject.SetActive(false);
                progressStarLetter[0].gameObject.SetActive(false);

                break;

            case 11:
                progressStarLetter[14].gameObject.SetActive(false);
                progressStarLetter[13].gameObject.SetActive(false);
                progressStarLetter[12].gameObject.SetActive(false);
                progressStarLetter[11].gameObject.SetActive(false);

                progressStarLetter[10].gameObject.SetActive(true);
                progressStarLetter[9].gameObject.SetActive(true);
                progressStarLetter[8].gameObject.SetActive(true);
                progressStarLetter[7].gameObject.SetActive(true);

                progressStarLetter[6].gameObject.SetActive(false);
                progressStarLetter[5].gameObject.SetActive(false);
                progressStarLetter[4].gameObject.SetActive(false);

                progressStarLetter[3].gameObject.SetActive(false);
                progressStarLetter[2].gameObject.SetActive(false);
                progressStarLetter[1].gameObject.SetActive(false);
                progressStarLetter[0].gameObject.SetActive(false);

                break;

            case 10:
                progressStarLetter[14].gameObject.SetActive(false);
                progressStarLetter[13].gameObject.SetActive(false);
                progressStarLetter[12].gameObject.SetActive(false);
                progressStarLetter[11].gameObject.SetActive(false);

                progressStarLetter[9].gameObject.SetActive(false);                        
                progressStarLetter[9].gameObject.SetActive(true);
                progressStarLetter[8].gameObject.SetActive(true);
                progressStarLetter[7].gameObject.SetActive(true);

                progressStarLetter[6].gameObject.SetActive(false);
                progressStarLetter[5].gameObject.SetActive(false);
                progressStarLetter[4].gameObject.SetActive(false);

                progressStarLetter[3].gameObject.SetActive(false);
                progressStarLetter[2].gameObject.SetActive(false);
                progressStarLetter[1].gameObject.SetActive(false);
                progressStarLetter[0].gameObject.SetActive(false);

                break;

            case 9:
                progressStarLetter[14].gameObject.SetActive(false);
                progressStarLetter[13].gameObject.SetActive(false);
                progressStarLetter[12].gameObject.SetActive(false);
                progressStarLetter[11].gameObject.SetActive(false);

                progressStarLetter[9].gameObject.SetActive(false);                        
                progressStarLetter[9].gameObject.SetActive(false);
                progressStarLetter[8].gameObject.SetActive(true);
                progressStarLetter[7].gameObject.SetActive(true);

                progressStarLetter[6].gameObject.SetActive(false);
                progressStarLetter[5].gameObject.SetActive(false);
                progressStarLetter[4].gameObject.SetActive(false);

                progressStarLetter[3].gameObject.SetActive(false);
                progressStarLetter[2].gameObject.SetActive(false);
                progressStarLetter[1].gameObject.SetActive(false);
                progressStarLetter[0].gameObject.SetActive(false);

                break;

            case 8:
                progressStarLetter[14].gameObject.SetActive(false);
                progressStarLetter[13].gameObject.SetActive(false);
                progressStarLetter[12].gameObject.SetActive(false);
                progressStarLetter[11].gameObject.SetActive(false);

                progressStarLetter[9].gameObject.SetActive(false);                        
                progressStarLetter[9].gameObject.SetActive(false);
                progressStarLetter[8].gameObject.SetActive(false);                    
                progressStarLetter[7].gameObject.SetActive(true);

                progressStarLetter[6].gameObject.SetActive(false);
                progressStarLetter[5].gameObject.SetActive(false);
                progressStarLetter[4].gameObject.SetActive(false);

                progressStarLetter[3].gameObject.SetActive(false);
                progressStarLetter[2].gameObject.SetActive(false);
                progressStarLetter[1].gameObject.SetActive(false);
                progressStarLetter[0].gameObject.SetActive(false);

                break;

            case 7:
                progressStarLetter[14].gameObject.SetActive(false);
                progressStarLetter[13].gameObject.SetActive(false);
                progressStarLetter[12].gameObject.SetActive(false);
                progressStarLetter[11].gameObject.SetActive(false);

                progressStarLetter[9].gameObject.SetActive(false);                        
                progressStarLetter[9].gameObject.SetActive(false);
                progressStarLetter[8].gameObject.SetActive(false);                    
                progressStarLetter[7].gameObject.SetActive(false);

                progressStarLetter[6].gameObject.SetActive(true);
                progressStarLetter[5].gameObject.SetActive(true);
                progressStarLetter[4].gameObject.SetActive(true);

                progressStarLetter[3].gameObject.SetActive(false);
                progressStarLetter[2].gameObject.SetActive(false);
                progressStarLetter[1].gameObject.SetActive(false);
                progressStarLetter[0].gameObject.SetActive(false);

                break;

            case 6:
                progressStarLetter[14].gameObject.SetActive(false);
                progressStarLetter[13].gameObject.SetActive(false);
                progressStarLetter[12].gameObject.SetActive(false);
                progressStarLetter[11].gameObject.SetActive(false);

                progressStarLetter[9].gameObject.SetActive(false);                        
                progressStarLetter[9].gameObject.SetActive(false);
                progressStarLetter[8].gameObject.SetActive(false);                    
                progressStarLetter[7].gameObject.SetActive(false);

                progressStarLetter[6].gameObject.SetActive(false);
                progressStarLetter[5].gameObject.SetActive(true);
                progressStarLetter[4].gameObject.SetActive(true);

                progressStarLetter[3].gameObject.SetActive(false);
                progressStarLetter[2].gameObject.SetActive(false);
                progressStarLetter[1].gameObject.SetActive(false);
                progressStarLetter[0].gameObject.SetActive(false);

                break;

            case 5:  
                progressStarLetter[14].gameObject.SetActive(false);
                progressStarLetter[13].gameObject.SetActive(false);
                progressStarLetter[12].gameObject.SetActive(false);
                progressStarLetter[11].gameObject.SetActive(false);

                progressStarLetter[9].gameObject.SetActive(false);                        
                progressStarLetter[9].gameObject.SetActive(false);
                progressStarLetter[8].gameObject.SetActive(false);                    
                progressStarLetter[7].gameObject.SetActive(false);

                progressStarLetter[7].gameObject.SetActive(false);
                progressStarLetter[6].gameObject.SetActive(false);
                progressStarLetter[5].gameObject.SetActive(false);                      
                progressStarLetter[4].gameObject.SetActive(true);

                progressStarLetter[3].gameObject.SetActive(false);
                progressStarLetter[2].gameObject.SetActive(false);
                progressStarLetter[1].gameObject.SetActive(false);
                progressStarLetter[0].gameObject.SetActive(false);

                break;

            case 4:  
                progressStarLetter[14].gameObject.SetActive(false);
                progressStarLetter[13].gameObject.SetActive(false);
                progressStarLetter[12].gameObject.SetActive(false);
                progressStarLetter[11].gameObject.SetActive(false);

                progressStarLetter[9].gameObject.SetActive(false);                        
                progressStarLetter[9].gameObject.SetActive(false);
                progressStarLetter[8].gameObject.SetActive(false);                    
                progressStarLetter[7].gameObject.SetActive(false);
                
                progressStarLetter[7].gameObject.SetActive(false);
                progressStarLetter[6].gameObject.SetActive(false);
                progressStarLetter[5].gameObject.SetActive(false);                      
                progressStarLetter[4].gameObject.SetActive(false); 

                progressStarLetter[3].gameObject.SetActive(true);
                progressStarLetter[2].gameObject.SetActive(true);
                progressStarLetter[1].gameObject.SetActive(true);
                progressStarLetter[0].gameObject.SetActive(true);

                break;

            case 3:
                progressStarLetter[14].gameObject.SetActive(false);
                progressStarLetter[13].gameObject.SetActive(false);
                progressStarLetter[12].gameObject.SetActive(false);
                progressStarLetter[11].gameObject.SetActive(false);

                progressStarLetter[9].gameObject.SetActive(false);                        
                progressStarLetter[9].gameObject.SetActive(false);
                progressStarLetter[8].gameObject.SetActive(false);                    
                progressStarLetter[7].gameObject.SetActive(false);
                
                progressStarLetter[7].gameObject.SetActive(false);
                progressStarLetter[6].gameObject.SetActive(false);
                progressStarLetter[5].gameObject.SetActive(false);                      
                progressStarLetter[4].gameObject.SetActive(false); 

                progressStarLetter[3].gameObject.SetActive(false);                    
                progressStarLetter[2].gameObject.SetActive(true);
                progressStarLetter[1].gameObject.SetActive(true);
                progressStarLetter[0].gameObject.SetActive(true);

                break;                    

            case 2:
                progressStarLetter[14].gameObject.SetActive(false);
                progressStarLetter[13].gameObject.SetActive(false);
                progressStarLetter[12].gameObject.SetActive(false);
                progressStarLetter[11].gameObject.SetActive(false);

                progressStarLetter[9].gameObject.SetActive(false);                        
                progressStarLetter[9].gameObject.SetActive(false);
                progressStarLetter[8].gameObject.SetActive(false);                    
                progressStarLetter[7].gameObject.SetActive(false);
                
                progressStarLetter[7].gameObject.SetActive(false);
                progressStarLetter[6].gameObject.SetActive(false);
                progressStarLetter[5].gameObject.SetActive(false);                      
                progressStarLetter[4].gameObject.SetActive(false); 

                progressStarLetter[3].gameObject.SetActive(false);
                progressStarLetter[2].gameObject.SetActive(false);                    
                progressStarLetter[1].gameObject.SetActive(true);
                progressStarLetter[0].gameObject.SetActive(true);

                break;

            case 1:
                progressStarLetter[14].gameObject.SetActive(false);
                progressStarLetter[13].gameObject.SetActive(false);
                progressStarLetter[12].gameObject.SetActive(false);
                progressStarLetter[11].gameObject.SetActive(false);

                progressStarLetter[9].gameObject.SetActive(false);                        
                progressStarLetter[9].gameObject.SetActive(false);
                progressStarLetter[8].gameObject.SetActive(false);                    
                progressStarLetter[7].gameObject.SetActive(false);
                
                progressStarLetter[7].gameObject.SetActive(false);
                progressStarLetter[6].gameObject.SetActive(false);
                progressStarLetter[5].gameObject.SetActive(false);                      
                progressStarLetter[4].gameObject.SetActive(false); 

                progressStarLetter[3].gameObject.SetActive(false);
                progressStarLetter[2].gameObject.SetActive(false);
                progressStarLetter[1].gameObject.SetActive(false);
                progressStarLetter[0].gameObject.SetActive(true);

                break;


                }           
    }

    void OnDestroy()
    {
        //This will happen whenever this object is destroyed, which includes scene changes
        // as well as existing the programs.
        Debug.Log ("Scene Object was destroyed.");

        PlayerPrefs.SetInt("LetterScore", indexScoreLetter);
        Debug.Log("Your score is " + indexScoreLetter );
                
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("pointTipHijaiyahLetter"))
        {   
            Debug.Log("GoAway");
            //To check if user is attempting for first time
            if (indexScoreLetter == currentPage)
            {
                progressDialogueBox[indexScoreLetter].gameObject.SetActive(true);
                Debug.Log("Hijaiyah letter " + currentPage + " completed" );

                // To set star object as active
                // Level 1
                switch (indexScoreLetter)
                {
                    case 15:
                        progressStarLetter[14].gameObject.SetActive(true);
                        progressStarLetter[13].gameObject.SetActive(true);
                        progressStarLetter[12].gameObject.SetActive(true);
                        progressStarLetter[11].gameObject.SetActive(true);

                        progressStarLetter[10].gameObject.SetActive(false);
                        progressStarLetter[9].gameObject.SetActive(false);
                        progressStarLetter[8].gameObject.SetActive(false);
                        progressStarLetter[7].gameObject.SetActive(false);

                        progressStarLetter[6].gameObject.SetActive(false);
                        progressStarLetter[5].gameObject.SetActive(false);
                        progressStarLetter[4].gameObject.SetActive(false);

                        progressStarLetter[3].gameObject.SetActive(false);
                        progressStarLetter[2].gameObject.SetActive(false);
                        progressStarLetter[1].gameObject.SetActive(false);
                        progressStarLetter[0].gameObject.SetActive(false);

                        break; 

                    case 14:
                        progressStarLetter[14].gameObject.SetActive(false);
                        progressStarLetter[13].gameObject.SetActive(true);
                        progressStarLetter[12].gameObject.SetActive(true);
                        progressStarLetter[11].gameObject.SetActive(true);

                        progressStarLetter[10].gameObject.SetActive(false);
                        progressStarLetter[9].gameObject.SetActive(false);
                        progressStarLetter[8].gameObject.SetActive(false);
                        progressStarLetter[7].gameObject.SetActive(false);

                        progressStarLetter[6].gameObject.SetActive(false);
                        progressStarLetter[5].gameObject.SetActive(false);
                        progressStarLetter[4].gameObject.SetActive(false);

                        progressStarLetter[3].gameObject.SetActive(false);
                        progressStarLetter[2].gameObject.SetActive(false);
                        progressStarLetter[1].gameObject.SetActive(false);
                        progressStarLetter[0].gameObject.SetActive(false);

                        break;

                    case 13:
                        progressStarLetter[14].gameObject.SetActive(false);
                        progressStarLetter[13].gameObject.SetActive(false);
                        progressStarLetter[12].gameObject.SetActive(true);
                        progressStarLetter[11].gameObject.SetActive(true);

                        progressStarLetter[10].gameObject.SetActive(false);
                        progressStarLetter[9].gameObject.SetActive(false);
                        progressStarLetter[8].gameObject.SetActive(false);
                        progressStarLetter[7].gameObject.SetActive(false);

                        progressStarLetter[6].gameObject.SetActive(false);
                        progressStarLetter[5].gameObject.SetActive(false);
                        progressStarLetter[4].gameObject.SetActive(false);

                        progressStarLetter[3].gameObject.SetActive(false);
                        progressStarLetter[2].gameObject.SetActive(false);
                        progressStarLetter[1].gameObject.SetActive(false);
                        progressStarLetter[0].gameObject.SetActive(false);

                        break;

                    case 12:
                        progressStarLetter[14].gameObject.SetActive(false);
                        progressStarLetter[13].gameObject.SetActive(false);
                        progressStarLetter[12].gameObject.SetActive(false);
                        progressStarLetter[11].gameObject.SetActive(true);

                        progressStarLetter[10].gameObject.SetActive(false);
                        progressStarLetter[9].gameObject.SetActive(false);
                        progressStarLetter[8].gameObject.SetActive(false);
                        progressStarLetter[7].gameObject.SetActive(false);

                        progressStarLetter[6].gameObject.SetActive(false);
                        progressStarLetter[5].gameObject.SetActive(false);
                        progressStarLetter[4].gameObject.SetActive(false);

                        progressStarLetter[3].gameObject.SetActive(false);
                        progressStarLetter[2].gameObject.SetActive(false);
                        progressStarLetter[1].gameObject.SetActive(false);
                        progressStarLetter[0].gameObject.SetActive(false);

                        break;

                    case 11:
                        progressStarLetter[14].gameObject.SetActive(false);
                        progressStarLetter[13].gameObject.SetActive(false);
                        progressStarLetter[12].gameObject.SetActive(false);
                        progressStarLetter[11].gameObject.SetActive(false);

                        progressStarLetter[10].gameObject.SetActive(true);
                        progressStarLetter[9].gameObject.SetActive(true);
                        progressStarLetter[8].gameObject.SetActive(true);
                        progressStarLetter[7].gameObject.SetActive(true);

                        progressStarLetter[6].gameObject.SetActive(false);
                        progressStarLetter[5].gameObject.SetActive(false);
                        progressStarLetter[4].gameObject.SetActive(false);

                        progressStarLetter[3].gameObject.SetActive(false);
                        progressStarLetter[2].gameObject.SetActive(false);
                        progressStarLetter[1].gameObject.SetActive(false);
                        progressStarLetter[0].gameObject.SetActive(false);

                        break;

                    case 10:
                        progressStarLetter[14].gameObject.SetActive(false);
                        progressStarLetter[13].gameObject.SetActive(false);
                        progressStarLetter[12].gameObject.SetActive(false);
                        progressStarLetter[11].gameObject.SetActive(false);

                        progressStarLetter[9].gameObject.SetActive(false);                        
                        progressStarLetter[9].gameObject.SetActive(true);
                        progressStarLetter[8].gameObject.SetActive(true);
                        progressStarLetter[7].gameObject.SetActive(true);

                        progressStarLetter[6].gameObject.SetActive(false);
                        progressStarLetter[5].gameObject.SetActive(false);
                        progressStarLetter[4].gameObject.SetActive(false);

                        progressStarLetter[3].gameObject.SetActive(false);
                        progressStarLetter[2].gameObject.SetActive(false);
                        progressStarLetter[1].gameObject.SetActive(false);
                        progressStarLetter[0].gameObject.SetActive(false);

                        break;

                    case 9:
                        progressStarLetter[14].gameObject.SetActive(false);
                        progressStarLetter[13].gameObject.SetActive(false);
                        progressStarLetter[12].gameObject.SetActive(false);
                        progressStarLetter[11].gameObject.SetActive(false);

                        progressStarLetter[9].gameObject.SetActive(false);                        
                        progressStarLetter[9].gameObject.SetActive(false);
                        progressStarLetter[8].gameObject.SetActive(true);
                        progressStarLetter[7].gameObject.SetActive(true);

                        progressStarLetter[6].gameObject.SetActive(false);
                        progressStarLetter[5].gameObject.SetActive(false);
                        progressStarLetter[4].gameObject.SetActive(false);

                        progressStarLetter[3].gameObject.SetActive(false);
                        progressStarLetter[2].gameObject.SetActive(false);
                        progressStarLetter[1].gameObject.SetActive(false);
                        progressStarLetter[0].gameObject.SetActive(false);

                        break;

                    case 8:
                        progressStarLetter[14].gameObject.SetActive(false);
                        progressStarLetter[13].gameObject.SetActive(false);
                        progressStarLetter[12].gameObject.SetActive(false);
                        progressStarLetter[11].gameObject.SetActive(false);

                        progressStarLetter[9].gameObject.SetActive(false);                        
                        progressStarLetter[9].gameObject.SetActive(false);
                        progressStarLetter[8].gameObject.SetActive(false);                    
                        progressStarLetter[7].gameObject.SetActive(true);

                        progressStarLetter[6].gameObject.SetActive(false);
                        progressStarLetter[5].gameObject.SetActive(false);
                        progressStarLetter[4].gameObject.SetActive(false);

                        progressStarLetter[3].gameObject.SetActive(false);
                        progressStarLetter[2].gameObject.SetActive(false);
                        progressStarLetter[1].gameObject.SetActive(false);
                        progressStarLetter[0].gameObject.SetActive(false);

                        break;

                    case 7:
                        progressStarLetter[14].gameObject.SetActive(false);
                        progressStarLetter[13].gameObject.SetActive(false);
                        progressStarLetter[12].gameObject.SetActive(false);
                        progressStarLetter[11].gameObject.SetActive(false);

                        progressStarLetter[9].gameObject.SetActive(false);                        
                        progressStarLetter[9].gameObject.SetActive(false);
                        progressStarLetter[8].gameObject.SetActive(false);                    
                        progressStarLetter[7].gameObject.SetActive(false);

                        progressStarLetter[6].gameObject.SetActive(true);
                        progressStarLetter[5].gameObject.SetActive(true);
                        progressStarLetter[4].gameObject.SetActive(true);

                        progressStarLetter[3].gameObject.SetActive(false);
                        progressStarLetter[2].gameObject.SetActive(false);
                        progressStarLetter[1].gameObject.SetActive(false);
                        progressStarLetter[0].gameObject.SetActive(false);

                        break;

                    case 6:
                        progressStarLetter[14].gameObject.SetActive(false);
                        progressStarLetter[13].gameObject.SetActive(false);
                        progressStarLetter[12].gameObject.SetActive(false);
                        progressStarLetter[11].gameObject.SetActive(false);

                        progressStarLetter[9].gameObject.SetActive(false);                        
                        progressStarLetter[9].gameObject.SetActive(false);
                        progressStarLetter[8].gameObject.SetActive(false);                    
                        progressStarLetter[7].gameObject.SetActive(false);

                        progressStarLetter[6].gameObject.SetActive(false);
                        progressStarLetter[5].gameObject.SetActive(true);
                        progressStarLetter[4].gameObject.SetActive(true);

                        progressStarLetter[3].gameObject.SetActive(false);
                        progressStarLetter[2].gameObject.SetActive(false);
                        progressStarLetter[1].gameObject.SetActive(false);
                        progressStarLetter[0].gameObject.SetActive(false);

                        break;

                    case 5:  
                        progressStarLetter[14].gameObject.SetActive(false);
                        progressStarLetter[13].gameObject.SetActive(false);
                        progressStarLetter[12].gameObject.SetActive(false);
                        progressStarLetter[11].gameObject.SetActive(false);

                        progressStarLetter[9].gameObject.SetActive(false);                        
                        progressStarLetter[9].gameObject.SetActive(false);
                        progressStarLetter[8].gameObject.SetActive(false);                    
                        progressStarLetter[7].gameObject.SetActive(false);

                        progressStarLetter[7].gameObject.SetActive(false);
                        progressStarLetter[6].gameObject.SetActive(false);
                        progressStarLetter[5].gameObject.SetActive(false);                      
                        progressStarLetter[4].gameObject.SetActive(true);

                        progressStarLetter[3].gameObject.SetActive(false);
                        progressStarLetter[2].gameObject.SetActive(false);
                        progressStarLetter[1].gameObject.SetActive(false);
                        progressStarLetter[0].gameObject.SetActive(false);

                        break;

                    case 4:  
                        progressStarLetter[14].gameObject.SetActive(false);
                        progressStarLetter[13].gameObject.SetActive(false);
                        progressStarLetter[12].gameObject.SetActive(false);
                        progressStarLetter[11].gameObject.SetActive(false);

                        progressStarLetter[9].gameObject.SetActive(false);                        
                        progressStarLetter[9].gameObject.SetActive(false);
                        progressStarLetter[8].gameObject.SetActive(false);                    
                        progressStarLetter[7].gameObject.SetActive(false);
                        
                        progressStarLetter[7].gameObject.SetActive(false);
                        progressStarLetter[6].gameObject.SetActive(false);
                        progressStarLetter[5].gameObject.SetActive(false);                      
                        progressStarLetter[4].gameObject.SetActive(false); 

                        progressStarLetter[3].gameObject.SetActive(true);
                        progressStarLetter[2].gameObject.SetActive(true);
                        progressStarLetter[1].gameObject.SetActive(true);
                        progressStarLetter[0].gameObject.SetActive(true);

                        break;

                    case 3:
                        progressStarLetter[14].gameObject.SetActive(false);
                        progressStarLetter[13].gameObject.SetActive(false);
                        progressStarLetter[12].gameObject.SetActive(false);
                        progressStarLetter[11].gameObject.SetActive(false);

                        progressStarLetter[9].gameObject.SetActive(false);                        
                        progressStarLetter[9].gameObject.SetActive(false);
                        progressStarLetter[8].gameObject.SetActive(false);                    
                        progressStarLetter[7].gameObject.SetActive(false);
                        
                        progressStarLetter[7].gameObject.SetActive(false);
                        progressStarLetter[6].gameObject.SetActive(false);
                        progressStarLetter[5].gameObject.SetActive(false);                      
                        progressStarLetter[4].gameObject.SetActive(false); 

                        progressStarLetter[3].gameObject.SetActive(false);                    
                        progressStarLetter[2].gameObject.SetActive(true);
                        progressStarLetter[1].gameObject.SetActive(true);
                        progressStarLetter[0].gameObject.SetActive(true);

                        break;                    

                    case 2:
                        progressStarLetter[14].gameObject.SetActive(false);
                        progressStarLetter[13].gameObject.SetActive(false);
                        progressStarLetter[12].gameObject.SetActive(false);
                        progressStarLetter[11].gameObject.SetActive(false);

                        progressStarLetter[9].gameObject.SetActive(false);                        
                        progressStarLetter[9].gameObject.SetActive(false);
                        progressStarLetter[8].gameObject.SetActive(false);                    
                        progressStarLetter[7].gameObject.SetActive(false);
                        
                        progressStarLetter[7].gameObject.SetActive(false);
                        progressStarLetter[6].gameObject.SetActive(false);
                        progressStarLetter[5].gameObject.SetActive(false);                      
                        progressStarLetter[4].gameObject.SetActive(false); 

                        progressStarLetter[3].gameObject.SetActive(false);
                        progressStarLetter[2].gameObject.SetActive(false);                    
                        progressStarLetter[1].gameObject.SetActive(true);
                        progressStarLetter[0].gameObject.SetActive(true);

                        break;

                    case 1:
                        progressStarLetter[14].gameObject.SetActive(false);
                        progressStarLetter[13].gameObject.SetActive(false);
                        progressStarLetter[12].gameObject.SetActive(false);
                        progressStarLetter[11].gameObject.SetActive(false);

                        progressStarLetter[9].gameObject.SetActive(false);                        
                        progressStarLetter[9].gameObject.SetActive(false);
                        progressStarLetter[8].gameObject.SetActive(false);                    
                        progressStarLetter[7].gameObject.SetActive(false);
                        
                        progressStarLetter[7].gameObject.SetActive(false);
                        progressStarLetter[6].gameObject.SetActive(false);
                        progressStarLetter[5].gameObject.SetActive(false);                      
                        progressStarLetter[4].gameObject.SetActive(false); 

                        progressStarLetter[3].gameObject.SetActive(false);
                        progressStarLetter[2].gameObject.SetActive(false);
                        progressStarLetter[1].gameObject.SetActive(false);
                        progressStarLetter[0].gameObject.SetActive(true);

                        break;


                }
                indexScoreLetter++;
                PlayerPrefs.SetInt("LetterScore", indexScoreLetter); 
            }
            Debug.Log("Don't Touch Me");
        }
    }
}
