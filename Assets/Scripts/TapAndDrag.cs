using UnityEngine;
using UnityEngine.EventSystems;

public class TapAndDrag : MonoBehaviour {
    private Transform defParent;
    private InputManager inputManager;
    public GameManager gameManager;
    private bool isTouched = false;
    private Camera cameraMain;
    private Vector3 defPos;
    private EventSystem eventHandler;
    private BoxCollider2D obsCollider;
    public bool rightAnswer = false;
    public GameObject obstacle;
    public bool isGameB = false;

    private void Awake() {
        inputManager = InputManager.Instance;
        defParent = transform.parent;
        cameraMain = Camera.main;
    }

    private void Start() {
        defPos = transform.position;
        obsCollider = obstacle.GetComponent<BoxCollider2D>();
        eventHandler = GameObject.FindObjectOfType<EventSystem>();
    }

    private void OnEnable() {
        inputManager.OnMoveTouch += Move;
        inputManager.OnEndTouch += EndTouch;
    }

    private void OnDisable() {
        inputManager.OnEndTouch -= EndTouch;
    }

    public void Move(Vector2 screenPosition) {
        if (!isTouched || screenPosition.x == Mathf.Infinity || screenPosition.y == Mathf.Infinity) return;
        Vector3 screenCoordinates = new Vector3(Mathf.Min(screenPosition.x, cameraMain.pixelWidth), Mathf.Max(screenPosition.y, -100f), 0f);
        Vector3 worldCoordinates = cameraMain.ScreenToWorldPoint(new Vector3(screenCoordinates.x, screenCoordinates.y, 0.3f));
        transform.position = isGameB ? worldCoordinates : screenCoordinates;
    }

    public void StartTouch(Vector2 screenPosition) {
        // TODO: Remove this if useless
    }

    public void EndTouch(Vector2 screenPosition) {
        if (!isTouched || screenPosition.x == Mathf.Infinity || screenPosition.y == Mathf.Infinity) return;
        if (obsCollider.OverlapPoint(cameraMain.ScreenToWorldPoint(screenPosition))) {
            if (rightAnswer) {
                if (!isGameB) {
                    gameManager.RightAnswerTrigger();
                } else {
                    gameManager.GameBTrigger();
                }
            } else {
                gameManager.WrongAnswerTrigger();
            }
        }
        isTouched = false;
        eventHandler.SetSelectedGameObject(null);
        transform.position = defPos;
    }

    private void Update() {
        if (eventHandler.currentSelectedGameObject != null)
            isTouched = eventHandler.currentSelectedGameObject?.name == transform.parent.name;
    }
}
