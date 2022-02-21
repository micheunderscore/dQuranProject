using UnityEngine;

[System.Serializable]
public class CharacterBehavior : MonoBehaviour {
    public float speed;
    private float runDuration;
    private int currentStop = 0;
    public float[] stops;
    public float loopOffset = 0f;
    public bool moving = false;
    public bool mainCharacter = false;
    private bool camFollow = true;
    private Rigidbody2D body;
    private Animator anim;

    private void Awake() {
        // CONFIGS
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // OLD
        runDuration = 1.975f / (speed * 0.1f);
    }

    private void Update() {
        if(body.position.x >= 80f - loopOffset) {
            body.gameObject.transform.localPosition = new Vector2(2f - loopOffset, body.position.y);
        }

        // if(!moving) {
        //     currentTime = runDuration;
        // }

        if(moving) {
            body.velocity = new Vector2(speed, body.velocity.y);
            GameObject.FindObjectOfType<Camera>().transform.SetParent(camFollow && mainCharacter ? body.transform : null);
            if(body.transform.localPosition.x >= stops[currentStop]) {
                moving = false;
                body.velocity = Vector2.zero;
                body.transform.localPosition = new Vector3(stops[currentStop], body.transform.localPosition.y, body.transform.localPosition.z);
                currentStop = currentStop == stops.Length - 1 ? 0 : currentStop + 1;
            }
        }

        anim.SetBool("run", moving);
    }

    public void triggerMove (bool withCamera) {
        moving = true;
        camFollow = withCamera;
    }
}
