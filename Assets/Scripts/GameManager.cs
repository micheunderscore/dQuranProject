using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject[] characters;
    // public static GameManager Instance;
    public DialogueManager dialogueManager;
    public GameState state;
    public bool started = false;
    
    public void Awake() {
        // Instance = this;
    }

    public void Start () {
        state = GameState.Dialogue;
        dialogueManager = FindObjectOfType<DialogueManager>();
        characters = GameObject.FindGameObjectsWithTag("Character");
    }

    public void Update() {
        if (!started) {
            dialogueManager.StartDialogue();
            TriggerCharacters();
            started = true;
        }
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