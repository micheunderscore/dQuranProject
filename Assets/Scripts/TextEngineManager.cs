using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextEngineManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject[] tutorialText;
    public int tutorialIndex;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        tutorialText[tutorialIndex].gameObject.SetActive(true);

        Debug.Log("Hovered");
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        tutorialText[tutorialIndex].gameObject.SetActive(false);

        Debug.Log("Hover Exited");
    }
}
