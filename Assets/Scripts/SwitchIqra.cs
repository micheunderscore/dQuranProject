using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchIqra : MonoBehaviour
{

    public GameObject[] iqra1;
    public GameObject[] iqra1NavBtn;
    public GameObject[] iqraTxtBar;

    int indexIqraPage;
    int indexTxtBar;


    // Start is called before the first frame update
    void Start()
    {
        indexIqraPage = 0;
        indexTxtBar = 0;
        iqra1[0].gameObject.SetActive(true);
        iqraTxtBar[0].gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (indexIqraPage >= 2)
        {
            indexIqraPage = 2;
        }

        if (indexIqraPage <= 0)
        {
            indexIqraPage = 0;
        }
    }

    public void NextIqra()
    {
        indexIqraPage++;

        for(int i = 0; i < iqra1.Length; i++)
        {
            iqra1[i].gameObject.SetActive(false);
            iqra1[indexIqraPage].gameObject.SetActive(true);
        }

            if (indexIqraPage == 2)
            {
                iqra1NavBtn[0].gameObject.SetActive(true);
                iqra1NavBtn[1].gameObject.SetActive(false);
            }

            else if (indexIqraPage > 0 && indexIqraPage < 2)
            {
                iqra1NavBtn[0].gameObject.SetActive(true);
                iqra1NavBtn[1].gameObject.SetActive(true);
            }
        Debug.Log(indexIqraPage);
    }

    public void PreviousIqra()
    {
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

            else if (indexIqraPage > 0 && indexIqraPage < 2)
            {
                iqra1NavBtn[0].gameObject.SetActive(true);
                iqra1NavBtn[1].gameObject.SetActive(true);
            }

        Debug.Log(indexIqraPage);
    }

    public void txtBarClicked()
    {
        indexTxtBar++;

        for (int i = 0; i <= indexTxtBar; i++)
        {
            iqraTxtBar[i].gameObject.SetActive(true);
        }

    }
}
