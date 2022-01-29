using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    public GameObject[] characters;
    public static GameManager Instance;
    // TODO: Make this work for passing data between scenes
    public DialogueManager dialogueManager;
    public GameObject dialogBox, wrongBox, gameBox, menuBox, letterObstacle, letterOutline;
    public TextMeshProUGUI letterTitle;
    public GameState state;
    public bool started = false;
    
    public void Awake() {
        Instance = this;
        // TODO: Testing purpose only. Remove all past this line in Awake()
        PlayerPrefs.SetString("username", "Jompot");
        PlayerPrefs.SetString("userColor", "#000000");
    }

    public void Start () {
        state = GameState.Dialogue;
        characters = GameObject.FindGameObjectsWithTag("Character");
    }

    public void Update() {
        if (!started) {
            dialogueManager.StartDialogue();
            TriggerCharacters();
            started = true;
        }

        dialogBox.SetActive(state == GameState.Dialogue);
        wrongBox.SetActive(state == GameState.WrongAnswer);
        gameBox.SetActive(state == GameState.Game);
        letterOutline.SetActive(state == GameState.Game);
        menuBox.SetActive(state == GameState.Menu);
    }

    public void GameTrigger() {
        // Do smth if player do good.
        string nextScene = dialogueManager.DisplayNextSentence();

        switch (nextScene) {
            case "@game":
                state = GameState.Game;
                break;
            case "@dialogue":
                state = GameState.Dialogue;
                break;
            case "@end":
            default:
                TriggerCharacters(false);
                state = GameState.Menu;
                break;
        }
        // TriggerCharacters();
    }

    public void TriggerCharacters (bool withCamera = true) {
        foreach (GameObject character in characters) {
            character.GetComponent<CharacterBehavior>().triggerMove(withCamera);
        }
    }

    public void RightAnswerTrigger () {
        letterObstacle.SetActive(false);
        GameTrigger();
    }

    public void RetryTrigger () {
        state = GameState.Game;
    }

    public void WrongAnswerTrigger () {
        state = GameState.WrongAnswer;
    }
}
// {
//     public static GameManager Instance;
//     public GameState State;

//     void Awake() {
//         Instance = this;
//     }
    
//     public void UpdateGameState(GameState newState) {
//         State = newState;

//         switch (newState) {
//             case GameState.SelectColor:
//                 break;
//             case GameState.PlayerTurn:
//                 break;
//             case GameState.EnemyTurn:
//                 break;
//             case GameState.Victory:
//                 break;
//             case GameState.Lose:
//                 break;
//             default:
//                 throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
//         }
//     }
// }

public enum GameState {
    Menu,
    Dialogue,
    Transition,
    Game,
    RightAnswer,
    WrongAnswer
}
