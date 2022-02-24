using System.Linq;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    public GameObject[] characters;
    public static GameManager Instance;
    // TODO: Make this work for passing data between scenes
    public DialogueManager dialogueManager;
    public GameObject dialogBox, wrongBox, gameBox, menuBox, pauseBox, pauseBtn, letterFilled, letterOutline, gameItem, gameUnfilled, gameFilled, optionalStart, optionalEnd;
    public GameObject star1, star2, star3;
    public TextMeshProUGUI letterTitle; // TODO: This is useless. Make it useful
    public GameState state, storedState;
    public GameState pastState = GameState.Menu;
    public bool started = false;
    public int currentLevel = 1;
    private float triggerTimer = 0f;
    private int score = 3;

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
            case GameState.Transition:
                dialogBox.SetActive(false);
                break;
            default:
                letterOutline.SetActive(true);
                dialogBox.SetActive(false);
                break;
        }

        wrongBox.SetActive(state == GameState.WrongAnswer);
        gameBox.SetActive(state == GameState.GameA);
        pauseBox.SetActive(state == GameState.Menu);
        
        star1.SetActive(score>=1);
        star2.SetActive(score>=2);
        star3.SetActive(score==3);
        menuBox.SetActive(state == GameState.EndScreen);
        pauseBtn.SetActive(state != GameState.Dialogue && state != GameState.Transition);

        bool stillMoving = false;

        foreach (GameObject character in characters) {
            stillMoving = character.GetComponent<CharacterBehavior>().moving || stillMoving;
        }

        if (stillMoving && state != GameState.Transition && state != GameState.EndScreen) {
            storedState = state;
            changeState(GameState.Transition);
        } else if (!stillMoving && storedState != GameState.Transition) {
            changeState(storedState);
            storedState = GameState.Transition;
        }

        // This is implementing trigger delay so that the user doesn't just spam through scenes
        if (Input.touchCount > 0 && triggerTimer <= 0f && !stillMoving) {
            switch (state) {
                case GameState.GameA:
                case GameState.GameB:
                case GameState.Transition:
                case GameState.Menu:
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
        if (state == GameState.EndScreen) {
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
                SaveSystem.CrossSceneInformation[currentLevel] = score;
                if (currentLevel >= SaveSystem.PassedGameProgress) SaveSystem.PassedGameProgress++;
                changeState(GameState.EndScreen);
                break;
        }
    }

    public void TriggerCharacters (bool withCamera = true) {
        foreach (GameObject character in characters) {
            character.GetComponent<CharacterBehavior>().triggerMove(withCamera);
        }
    }

    public void GameBTrigger () {
        if(gameFilled != null && gameUnfilled != null && gameItem != null) {
            gameFilled.SetActive(true);
            gameUnfilled.SetActive(false);
            gameItem.SetActive(false);
        }
        GameTrigger();
    }

    public void RightAnswerTrigger () {
        letterFilled.SetActive(true);
        if(optionalEnd != null && optionalStart != null) {
            optionalEnd.SetActive(true);
            optionalStart.SetActive(false);
        }
        GameTrigger();
    }

    public void RetryTrigger () {
        if(score != 0) {
            score -= 1;
        }
        changeState(GameState.GameA);
    }

    public void WrongAnswerTrigger () {
        changeState(GameState.WrongAnswer);
    }
    
    private void changeState(GameState newState) {
        state = newState;
        triggerTimer = 0.5f;
    }

    public void TriggerMenu () {
        if (pastState != GameState.Menu) {
            state = pastState;
            pastState = GameState.Menu;
        } else {
            pastState = state;
            state = GameState.Menu;
        }
    }
}

public enum GameState {
    EndScreen,
    Dialogue,
    Transition,
    GameA,
    GameB,
    RightAnswer,
    WrongAnswer,
    Menu
}
