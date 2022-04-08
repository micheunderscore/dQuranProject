using UnityEngine;

public class TapToContinue : MonoBehaviour {
    public GameManager gameManager;
    private int textState;
    private Animator anim;

    void Awake() {
        anim = GetComponent<Animator>();
    }

    void Update() {
        Debug.Log("Tutorial:::" + Input.touchCount);
        if (gameManager.state == GameState.Dialogue) {
            textState = 1;
        }
        if (Input.touchCount > 0) {
            textState = 2;
        }

        anim.SetInteger("State", textState);
    }
}
