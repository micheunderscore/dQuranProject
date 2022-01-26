using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float runDuration = 2f;
    [SerializeField] private float currentTime;
    [SerializeField] private float loopOffset = 0f;
    private Rigidbody2D body;
    private Animator anim;
    [SerializeField] private bool moving = false;
    // private bool grounded;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentTime = runDuration;
    }

    private void Update() {
        if(body.position.x >= 80f - loopOffset)
            body.gameObject.transform.localPosition = new Vector2(2f - loopOffset, body.position.y);

        if(Input.GetKey(KeyCode.Space) && !moving) {
            currentTime = runDuration;
            moving = true;
        }

        if(moving) {
            currentTime -= 1f * Time.deltaTime;
            body.velocity = new Vector2(speed, body.velocity.y);
            if(currentTime <= 0f) {
                moving = false;
                body.velocity = Vector2.zero;
            }
        }

        anim.SetBool("run", moving);
    }

    // private void Update() {
    //     float horizontalInput = Input.GetAxis("Horizontal");
    //     body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

    //     if(horizontalInput > 0.01f) {
    //         transform.localScale = Vector3.one;
    //     } else if(horizontalInput < -0.01f) {
    //         transform.localScale = new Vector3(-1, 1, 1);
    //     }

    //     if(Input.GetAxis("Vertical") > 0 && grounded) 
    //         Jump();

    //     anim.SetBool("run", horizontalInput != 0);
    //     anim.SetBool("grounded", grounded);
    // }

    // private void Jump() {
    //     body.velocity = new Vector2(body.velocity.x, speed / 2);
    //     anim.SetTrigger("jump");
    //     grounded = false;
    // }

    // private void OnCollisionEnter2D(Collision2D collision) {
    //     if(collision.gameObject.tag == "Ground")
    //         grounded = true;
    // }
}
