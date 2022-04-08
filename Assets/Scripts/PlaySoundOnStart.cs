using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlaySoundOnStart : MonoBehaviour
{
    
    [SerializeField] private AudioClip _clip;


    public void buttonOnClicked()
    {
        
        SoundManager.Instance.PlaySound(_clip);

        Debug.Log("Clicked and Sound Played");
    }
        
}
