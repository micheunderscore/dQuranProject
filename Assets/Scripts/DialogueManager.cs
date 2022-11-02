using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour {
    public List<Vector3> uiPositions = new List<Vector3>();
    private Queue<Dialog> sentences = new Queue<Dialog>();
    private string path;
    private string jsonString;
    private JsonReader jsonReader = new JsonReader();
    private Dialogue dialogue;
    private string username;
    private TextMeshProUGUI dialogText, namePlate;
    public GameObject dialogBox;
    public GameManager gameManager;

    void Awake() {
        username = jsonReader.GetUsername();
    }

    void Start() {
        jsonString = jsonReader.Read("Dialogues" + Path.DirectorySeparatorChar + "levels.json");
        dialogue = JsonUtility.FromJson<Dialogues>(jsonString).dialogues[gameManager.currentLevel - 1];

        gameManager.letterTitle.text = dialogue.title;

        dialogText = dialogBox.transform.Find("TextBar").transform.Find("DialogText").GetComponent<TextMeshProUGUI>();
        namePlate = dialogBox.transform.Find("TextBar").transform.Find("NamePlate").GetComponent<TextMeshProUGUI>();
    }

    public void StartDialogue() {
        sentences.Clear();
        foreach (Dialog sentence in dialogue.languages.en) { // TODO: Modify when Change Language screen is implemented
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public string DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialogue();
            return "@end";
        }

        Dialog sentence = sentences.Dequeue();

        if (Regex.IsMatch(sentence.name, "@game")) {
            return sentence.name;
        } else {
            DisplayText(sentence);
            return "@dialogue";
        }
    }

    public void DisplayText(Dialog conversation) {
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
            dialogBox.transform.Find("TextBar").transform.localPosition = uiPositions[index];
        }

        dialogText.text = conversation.sentence.Replace("@user", username);
        namePlate.text = "- " + conversation.name;
    }

    public void EndDialogue() {
        // TODO: Remove this if no use
    }
}
