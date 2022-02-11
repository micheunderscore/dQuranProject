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
    public bool rightAnswer = false;
    public GameObject canvas;

    private void Awake() {
        inputManager = InputManager.Instance;
        defParent = transform.parent;
        cameraMain = Camera.main;
    }

    private void Start() {
        defPos = transform.position;
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
        transform.position = screenCoordinates;
    }

    public void StartTouch(Vector2 screenPosition) {
        // Debug.Log(transform.gameObject.name + "StartTouch " + screenPosition);
    }

    public void EndTouch(Vector2 screenPosition) {
        if (!isTouched || screenPosition.x == Mathf.Infinity || screenPosition.y == Mathf.Infinity) return;
        Debug.Log(transform.gameObject.name + " Triggered " + screenPosition + isTouched);
        if (screenPosition.x < (cameraMain.pixelWidth / 2f) + 20f) {
            if (rightAnswer) {
                gameManager.RightAnswerTrigger();
                Debug.Log("Right Answer");
            } else {
                gameManager.WrongAnswerTrigger();
                Debug.Log("Wrong Answer");
            }
        }
        isTouched = false;
        eventHandler.SetSelectedGameObject(null);
        transform.position = defPos;
    }

    private void Update() {
        if (eventHandler.currentSelectedGameObject != null)
            isTouched = eventHandler.currentSelectedGameObject?.name == transform.parent.name;
        // inputManager.OnStartTouch += Move;
        // if (Input.touchCount > 0) {
        //     transform.SetParent(canvas.transform);
        //     Touch touch = Input.GetTouch(0);
        //     Vector3 touchPosition = new Vector3(touch.position.x - cameraMain.pixelWidth / 2f, touch.position.y - cameraMain.pixelHeight / 2f, 0f);
        //     transform.localPosition = touchPosition;
        // } else {
        //     transform.SetParent(defParent);
        // }
    }
}
