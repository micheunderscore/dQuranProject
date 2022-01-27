using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public List<Vector3> uiPositions = new List<Vector3>();
    private Queue<Convo> sentences = new Queue<Convo>();
    private string path;
    private string jsonString;
    private JsonReader jsonReader = new JsonReader();
    private Dialogue dialogue;
    private string username;
    [SerializeField] public TextMeshProUGUI dialogBox;
    [SerializeField] public TextMeshProUGUI namePlate;

    void Awake () {
        username = jsonReader.GetUsername();
        uiPositions.Add(new Vector3(-175f, 6f, 0f));
        uiPositions.Add(new Vector3(181f, -45f, 0f));
    }
    
    void Start() {
        jsonString = jsonReader.Read("/Dialogues/level1.json");
        dialogue = JsonUtility.FromJson<Dialogue>(jsonString);
    }

    public void StartDialogue () {
        sentences.Clear();
        foreach (Convo sentence in dialogue.conversation) {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public string DisplayNextSentence () {
        if (sentences.Count == 0) {
            EndDialogue();
            return "@end";
        }

        Convo sentence = sentences.Dequeue();
        
        if (sentence.name == "@game") {
            Debug.Log("Is only game");
            return sentence.name;
        } else {
            DisplayText(sentence);
            return "@dialogue";
        }
    }

    public void DisplayText (Convo conversation) {
        int index = 0;
        switch (conversation.name) {
            case "@user":
                index = 0;
                break;
            default:
                index = 1;
                break;
        }
        GameObject.FindGameObjectWithTag("DialogBox").transform.localPosition = uiPositions[index];

        dialogBox.text = conversation.sentence.Replace("@user", username);
        namePlate.text = conversation.name.Replace("@user", username);
    }

    public void EndDialogue () {
        dialogBox.text = "End of conversation";
        Debug.Log("End of conversation");
    }
}
