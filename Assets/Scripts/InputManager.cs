using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

[DefaultExecutionOrder(-1)]
public class InputManager : Singleton<InputManager> {
    public delegate void StartTouchEvent(Vector2 position);
    public event StartTouchEvent OnStartTouch;
    public delegate void EndTouchEvent(Vector2 position);
    public event EndTouchEvent OnEndTouch;
    public delegate void MoveTouchEvent(Vector2 position);
    public event MoveTouchEvent OnMoveTouch;

    private void OnEnable() {
        EnhancedTouchSupport.Enable();
        TouchSimulation.Enable();

        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerMove += FingerMove;
    }

    private void OnDisable() {
        EnhancedTouchSupport.Disable();
        TouchSimulation.Disable();

        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerMove -= FingerMove;
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerUp -= EndTouch;
    }

    private void Start() {
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += StartTouch;
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerUp += EndTouch;
    }

    private void StartTouch(Finger finger) {
        Vector2 touchPosition = finger.screenPosition;
        if (OnStartTouch != null) OnStartTouch(touchPosition);
    }

    private void EndTouch(Finger finger) {
        Vector2 touchPosition = finger.screenPosition;
        if (OnEndTouch != null) OnEndTouch(touchPosition);
    }

    private void FingerMove(Finger finger) {
        if (OnMoveTouch != null) OnMoveTouch(finger.screenPosition);
    }
}
