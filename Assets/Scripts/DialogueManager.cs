using System.IO;
using System.Text.RegularExpressions;
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
    private TextMeshProUGUI dialogText, namePlate;
    public GameObject dialogBox;
    public GameManager gameManager;

    void Awake () {
        username = jsonReader.GetUsername();
    }
    
    void Start() {
        jsonString = jsonReader.Read("Dialogues" + Path.DirectorySeparatorChar + "level"+ gameManager.currentLevel +".json");
        dialogue = JsonUtility.FromJson<Dialogue>(jsonString);

        dialogText = dialogBox.transform.Find("DialogText").GetComponent<TextMeshProUGUI>();
        namePlate = dialogBox.transform.Find("NamePlate").GetComponent<TextMeshProUGUI>();
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
        
        if (Regex.IsMatch(sentence.name, "@game")) {
            return sentence.name;
        } else {
            DisplayText(sentence);
            return "@dialogue";
        }
    }

    public void DisplayText (Convo conversation) {
        int index = 0;
        switch (conversation.name) {
            case "Alif":
                index = 0;
                break;
            default:
                index = 1;
                break;
        }
        if (dialogBox.activeSelf) {
            dialogBox.transform.localPosition = uiPositions[index];
        }

        dialogText.text = conversation.sentence.Replace("@user", username);
        namePlate.text = "- " + conversation.name;
    }

    public void EndDialogue () {
        // TODO: Remove this if no use
    }
}
