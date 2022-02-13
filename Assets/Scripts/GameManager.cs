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
    public TextMeshProUGUI letterTitle; // TODO: This is useless. Make it useful
    public GameState state;
    public bool started = false;
    private float triggerTimer = 0f;

    public void Awake() {
        Instance = this;
        // TODO: Testing purpose only. Remove all past this line in Awake()
        PlayerPrefs.SetString("username", "Mel");
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

        switch (state) {
            case GameState.Dialogue:
            case GameState.GameB:
                letterOutline.SetActive(false);
                dialogBox.SetActive(true);
                break;
            default:
                letterOutline.SetActive(true);
                dialogBox.SetActive(false);
                break;
        }

        wrongBox.SetActive(state == GameState.WrongAnswer);

        gameBox.SetActive(state == GameState.GameA);

        menuBox.SetActive(state == GameState.Menu);

        bool stillMoving = false; // TODO: Change stillMoving to state == GameState.Transition

        foreach (GameObject character in characters) {
            stillMoving = character.GetComponent<CharacterBehavior>().moving || stillMoving;
        }
        
        Debug.Log("Still Moving :" + stillMoving);

        // This is implementing trigger delay so that the user doesn't just spam through scenes
        if (Input.touchCount > 0 && triggerTimer <= 0f && !stillMoving) {
            switch (state) {
                case GameState.GameA:
                case GameState.GameB:
                    Debug.Log(state);
                    break;
                case GameState.WrongAnswer:
                    RetryTrigger();
                    break;
                default:
                    GameTrigger();
                    triggerTimer = 0.5f;
                    break;
            }
        } else {
            triggerTimer -= 1 * Time.deltaTime;
        };
    }

    public void GameTrigger() {
        if (state == GameState.Menu) {
            return;
        }

        string nextScene = dialogueManager.DisplayNextSentence(); // TODO: Move this to the switch case brackets

        switch (nextScene) {
            case "@gameA":
                changeState(GameState.GameA);
                break;
            case "@gameB":
                changeState(GameState.GameB);
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

    public void GameBTrigger () {
        // TODO: Display correct placement obstacle
        // TODO: Hide wrong placement Obstacle
        // TODO: Trigger next event
        GameTrigger();
    }

    public void RightAnswerTrigger () {
        letterFilled.SetActive(true);
        GameTrigger();
    }

    public void RetryTrigger () {
        changeState(GameState.GameA);
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
    Transition, // TODO: Use Transition game state
    GameA,
    GameB,
    RightAnswer,
    WrongAnswer
}
