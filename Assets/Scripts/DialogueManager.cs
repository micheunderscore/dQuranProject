using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
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
        dialogBox.text = conversation.sentence.Replace("@user", username);
        namePlate.text = conversation.name.Replace("@user", username);
    }

    public void EndDialogue () {
        dialogBox.text = "End of conversation";
        Debug.Log("End of conversation");
    }
}
