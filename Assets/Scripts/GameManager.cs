using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    public GameObject[] characters;
    public static GameManager Instance;
    // TODO: Make this work for passing data between scenes
    public DialogueManager dialogueManager;
    public GameObject dialogBox, wrongBox, gameBox, menuBox, letterFilled, letterOutline;
    public TextMeshProUGUI letterTitle;
    public GameState state;
    public bool started = false;
    private float triggerTimer = 0f;

    public void Awake() {
        Instance = this;
        // TODO: Testing purpose only. Remove all past this line in Awake()
        PlayerPrefs.SetString("username", "Alif");
        PlayerPrefs.SetString("userColor", "#000000");
    }

    public void Start () {
        changeState(GameState.Dialogue);
        characters = GameObject.FindGameObjectsWithTag("Character");
    }

    public void Update() {
        if (!started) {
            dialogueManager.StartDialogue();
            TriggerCharacters();
            triggerTimer = 2f;
            started = true;
        }

        dialogBox.SetActive(state == GameState.Dialogue);
        wrongBox.SetActive(state == GameState.WrongAnswer);
        gameBox.SetActive(state == GameState.Game);
        letterOutline.SetActive(state == GameState.Game);
        menuBox.SetActive(state == GameState.Menu);

        bool stillMoving = false;

        foreach (GameObject character in characters) {
            stillMoving = character.GetComponent<CharacterBehavior>().moving || stillMoving;
        }
        
        Debug.Log("Still Moving :" + stillMoving);
        
        if (Input.touchCount > 0 && triggerTimer <= 0f && !stillMoving) {
            if (state == GameState.WrongAnswer) {
                RetryTrigger();
            } else if (state != GameState.Game) {
                GameTrigger();
                triggerTimer = 0.5f;
            }
        } else {
            triggerTimer -= 1 * Time.deltaTime;
        };
    }

    public void GameTrigger() {
        if (state == GameState.Menu) {
            return;
        }

        string nextScene = dialogueManager.DisplayNextSentence();

        switch (nextScene) {
            case "@game":
                changeState(GameState.Game);
                break;
            case "@dialogue":
                changeState(GameState.Dialogue);
                break;
            case "@end":
            default:
                TriggerCharacters(false);
                changeState(GameState.Menu);
                break;
        }
    }

    public void TriggerCharacters (bool withCamera = true) {
        foreach (GameObject character in characters) {
            character.GetComponent<CharacterBehavior>().triggerMove(withCamera);
        }
    }

    public void RightAnswerTrigger () {
        letterFilled.SetActive(true);
        GameTrigger();
    }

    public void RetryTrigger () {
        changeState(GameState.Game);
    }

    public void WrongAnswerTrigger () {
        changeState(GameState.WrongAnswer);
    }
    
    private void changeState(GameState newState) {
        state = newState;
        triggerTimer = 0.5f;
    }
}

public enum GameState {
    Menu,
    Dialogue,
    Transition,
    Game,
    RightAnswer,
    WrongAnswer
}
