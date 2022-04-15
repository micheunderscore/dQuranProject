using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonToggle : MonoBehaviour
{
    [SerializeField] private Sprite[] buttonSprites;
    [SerializeField] private Image targetButton;


    // Start is called before the first frame update
    public void ChangeSprite()
    {
         if (targetButton.sprite == buttonSprites[0])
         {
             targetButton.sprite = buttonSprites[1];
             return;
         }

         targetButton.sprite = buttonSprites[0];
    }
}
