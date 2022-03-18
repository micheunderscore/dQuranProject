using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchIqra : MonoBehaviour
{

    public GameObject[] iqra1; //by page
    int indexIqraPage;

    public GameObject[] iqra1NavBtn;
    // separation by line
    
    // text
    public GameObject[] iqra1LineOne;
    public GameObject[] iqra1LineTwo;
    public GameObject[] iqra1LineThree;

    // toggle text
    public GameObject[] iqra1LineOneToggle;
    public GameObject[] iqra1LineTwoToggle;
    public GameObject[] iqra1LineThreeToggle;

    // audio source
    public AudioSource[] iqra1AudioLineOne;
    public AudioSource[] iqra1AudioLineTwo;
    public AudioSource[] iqra1AudioLineThree;

    


    // Start is called before the first frame update
    void Start()
    {
        indexIqraPage = 0;
        iqra1[0].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (indexIqraPage >= 26)
        {
            indexIqraPage = 26;
        }

        if (indexIqraPage <= 0)
        {
            indexIqraPage = 0;
        }
    }

    public void NextIqra()
    {   
        iqra1LineOneToggle[indexIqraPage].gameObject.SetActive(false);
        iqra1LineTwoToggle[indexIqraPage].gameObject.SetActive(false);
        iqra1LineThreeToggle[indexIqraPage].gameObject.SetActive(false);
        
        iqra1LineOne[indexIqraPage].gameObject.SetActive(true);
        iqra1LineTwo[indexIqraPage].gameObject.SetActive(true);
        iqra1LineThree[indexIqraPage].gameObject.SetActive(true);

        iqra1AudioLineOne[indexIqraPage].Stop();
        iqra1AudioLineTwo[indexIqraPage].Stop();
        iqra1AudioLineThree[indexIqraPage].Stop();

        indexIqraPage++;

        for(int i = 0; i < iqra1.Length; i++)
        {
            iqra1[i].gameObject.SetActive(false);
            iqra1[indexIqraPage].gameObject.SetActive(true);
        }

            if (indexIqraPage == 26)
            {
                iqra1NavBtn[0].gameObject.SetActive(true);
                iqra1NavBtn[1].gameObject.SetActive(false);
            }

            else if (indexIqraPage > 0 && indexIqraPage < 26)
            {
                iqra1NavBtn[0].gameObject.SetActive(true);
                iqra1NavBtn[1].gameObject.SetActive(true);
            }
        Debug.Log(indexIqraPage);
    }

    public void PreviousIqra()
    {
        iqra1LineOneToggle[indexIqraPage].gameObject.SetActive(false);
        iqra1LineTwoToggle[indexIqraPage].gameObject.SetActive(false);
        iqra1LineThreeToggle[indexIqraPage].gameObject.SetActive(false);
        
        iqra1LineOne[indexIqraPage].gameObject.SetActive(true);
        iqra1LineTwo[indexIqraPage].gameObject.SetActive(true);
        iqra1LineThree[indexIqraPage].gameObject.SetActive(true);
        
        iqra1AudioLineOne[indexIqraPage].Stop();
        iqra1AudioLineTwo[indexIqraPage].Stop();
        iqra1AudioLineThree[indexIqraPage].Stop();

        indexIqraPage--;

        for(int i = 0; i < iqra1.Length; i++)
        {
            iqra1[i].gameObject.SetActive(false);
            iqra1[indexIqraPage].gameObject.SetActive(true);
        }
           
            if (indexIqraPage == 0)
            {
                iqra1NavBtn[0].gameObject.SetActive(false);
                iqra1NavBtn[1].gameObject.SetActive(true);
            }

            else if (indexIqraPage > 0 && indexIqraPage < 26)
            {
                iqra1NavBtn[0].gameObject.SetActive(true);
                iqra1NavBtn[1].gameObject.SetActive(true);
            }

        Debug.Log(indexIqraPage);
    }

    // Line One 
    public void iqraOneLineOneOnClicked()
    {
        iqra1AudioLineOne[indexIqraPage].Play();
        iqra1AudioLineTwo[indexIqraPage].Stop();
        iqra1AudioLineThree[indexIqraPage].Stop();

        //Close Toggle for All other clicked line
        iqra1LineTwoToggle[indexIqraPage].gameObject.SetActive(false);
        iqra1LineThreeToggle[indexIqraPage].gameObject.SetActive(false);
        
        //Set Active Their Original img
        iqra1LineTwo[indexIqraPage].gameObject.SetActive(true);
        iqra1LineThree[indexIqraPage].gameObject.SetActive(true);

        //Turn off original line one img and set active toggle img.
        iqra1LineOne[indexIqraPage].gameObject.SetActive(false);
        iqra1LineOneToggle[indexIqraPage].gameObject.SetActive(true);
    }

    public void iqraOneLineOneToggleOnClicked()
    {   
        iqra1AudioLineOne[indexIqraPage].Stop();       
        
        iqra1LineOneToggle[indexIqraPage].gameObject.SetActive(false);
        iqra1LineOne[indexIqraPage].gameObject.SetActive(true);
    }

    //Line Two
    public void iqraOneLineTwoOnClicked()
    {
        iqra1AudioLineOne[indexIqraPage].Stop();
        iqra1AudioLineTwo[indexIqraPage].Play();
        iqra1AudioLineThree[indexIqraPage].Stop();

        iqra1LineOneToggle[indexIqraPage].gameObject.SetActive(false);
        iqra1LineThreeToggle[indexIqraPage].gameObject.SetActive(false);
        iqra1LineOne[indexIqraPage].gameObject.SetActive(true);
        iqra1LineThree[indexIqraPage].gameObject.SetActive(true);

        iqra1LineTwoToggle[indexIqraPage].gameObject.SetActive(true);
        iqra1LineTwo[indexIqraPage].gameObject.SetActive(false);
    }

    public void iqraOneLineTwoToggleOnClicked()
    {
        iqra1AudioLineTwo[indexIqraPage].Stop();       
           
        iqra1LineTwoToggle[indexIqraPage].gameObject.SetActive(false);
        iqra1LineTwo[indexIqraPage].gameObject.SetActive(true);
    }    

    // Line Three
    public void iqraOneLineThreeOnClicked()
    {
        iqra1AudioLineOne[indexIqraPage].Stop();
        iqra1AudioLineTwo[indexIqraPage].Stop();
        iqra1AudioLineThree[indexIqraPage].Play();

        iqra1LineOneToggle[indexIqraPage].gameObject.SetActive(false);
        iqra1LineTwoToggle[indexIqraPage].gameObject.SetActive(false);
        iqra1LineOne[indexIqraPage].gameObject.SetActive(true);
        iqra1LineTwo[indexIqraPage].gameObject.SetActive(true);

        iqra1LineThree[indexIqraPage].gameObject.SetActive(false);
        iqra1LineThreeToggle[indexIqraPage].gameObject.SetActive(true);
    }

    public void iqraOneLineThreeToggleOnClicked()
    {
        iqra1AudioLineThree[indexIqraPage].Stop();       

        iqra1LineThreeToggle[indexIqraPage].gameObject.SetActive(false);
        iqra1LineThree[indexIqraPage].gameObject.SetActive(true);
    }

}
