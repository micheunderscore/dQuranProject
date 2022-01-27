using System;
using UnityEngine;

[System.Serializable]
public class CharacterBehavior : MonoBehaviour {
    public float speed;
    private float runDuration;
    public float currentTime;
    public float loopOffset = 0f;
    public bool moving = false;
    private bool camFollow = true;
    private Rigidbody2D body;
    private Animator anim;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        runDuration = 1.975f / (speed * 0.1f);
    }

    private void Update() {
        if(body.position.x >= 80f - loopOffset)
            body.gameObject.transform.localPosition = new Vector2(2f - loopOffset, body.position.y);

        if(!moving) {
            currentTime = runDuration;
        }

        if(moving) {
            currentTime -= 1f * Time.deltaTime;
            body.velocity = new Vector2(speed, body.velocity.y);
            GameObject.FindObjectOfType<Camera>().transform.SetParent(camFollow ? body.transform : null);
            if(currentTime <= 0f) {
                moving = false;
                body.velocity = Vector2.zero;
            }
        }

        anim.SetBool("run", moving);
    }

    public void triggerMove (bool withCamera) {
        moving = true;
        camFollow = withCamera;
    }
}
