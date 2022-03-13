using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class switchListLetter : MonoBehaviour
{
    public GameObject[] listLevelSelect;
    public GameObject[] listNavBtn;

    public int indexLvl;
    int indexPreviousLvl;

    // Start is called before the first frame update
    void Start()
    {
        indexLvl = PlayerPrefs.GetInt("IndexLvlLetter", 0);
        listLevelSelect[indexLvl].gameObject.SetActive(true);

        if (indexLvl == 0)
        {
            listNavBtn[0].gameObject.SetActive(false);
            listNavBtn[1].gameObject.SetActive(true);
        }

        else if (indexLvl == 7)
        {
            listNavBtn[0].gameObject.SetActive(true);
            listNavBtn[1].gameObject.SetActive(false);
        }

        else if (indexLvl > 0 && indexLvl < 7)
        {
            listNavBtn[0].gameObject.SetActive(true);
            listNavBtn[1].gameObject.SetActive(true);
        }    

    }

    // Update is called once per frame
    void Update()
    {
        if(indexLvl >= 7)
        {
            indexLvl = 7;
        }

        if(indexLvl <= 0)
        {
            indexLvl = 0;
        }
    }

    public void NextLvlList()
    {
        indexLvl++;

        for(int i = 0; i < listLevelSelect.Length; i++)
        {
            listLevelSelect[i].gameObject.SetActive(false);
            listLevelSelect[indexLvl].gameObject.SetActive(true);
        }

        if(indexLvl == 7)
        {
            listNavBtn[0].gameObject.SetActive(true);
            listNavBtn[1].gameObject.SetActive(false);
        }

        else if (indexLvl > 0 && indexLvl < 7)
        {
            listNavBtn[0].gameObject.SetActive(true);
            listNavBtn[1].gameObject.SetActive(true);            
        }

        Debug.Log("Your current index in this list is " + indexLvl );
    }

    public void PreviousLvlList()
    {
        indexLvl--;

        for(int i = 0; i < listLevelSelect.Length; i++)
        {
            listLevelSelect[i].gameObject.SetActive(false);
            listLevelSelect[indexLvl].gameObject.SetActive(true);
        }

        if(indexLvl == 0)
        {
            listNavBtn[0].gameObject.SetActive(false);
            listNavBtn[1].gameObject.SetActive(true);
        }

        else if (indexLvl > 0 && indexLvl < 7)
        {
            listNavBtn[0].gameObject.SetActive(true);
            listNavBtn[1].gameObject.SetActive(true);            
        }

        Debug.Log("Your current index in this list is " + indexLvl );
    }

}
