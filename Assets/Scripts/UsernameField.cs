using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UsernameField : MonoBehaviour
{
    private TMP_InputField inputField;

    void Awake()
    {
        // TODO: Integrate or remove in the future :))))
        PlayerPrefs.SetString("userColor", "#000000");
    }

    void Start()
    {
        inputField = this.gameObject.GetComponent<TMP_InputField>();
        inputField.text = PlayerPrefs.GetString("username", "Mel");
    }

    public void SetUsername()
    {
        if (string.IsNullOrEmpty(inputField.text))
        {
            PlayerPrefs.DeleteKey("username");
        }
        else
        {
            PlayerPrefs.SetString("username", inputField.text);
        }
    }
}
