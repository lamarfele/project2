using UnityEngine;
using UnityEngine.InputSystem;

public class platform : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    private float moveX;
    [SerializeField] private float jumpForce;  
    public bool isTouchingGround;
    public int coinCollected = 0;
    private Animator anim;
    private SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("speed", Mathf.Abs(moveX));
        anim.SetFloat("yVelocity", rb.linearVelocityY);
        anim.SetBool("isGrounded", isTouchingGround);

        if (moveX > 0) sr.flipX = false;
        else if (moveX < 0) sr.flipX = true;      
    }

    private void FixedUpdate()
    {
        rb.linearVelocityX = moveX * moveSpeed;
    }

    void OnMove(InputValue value)
    {
        moveX = value.Get<Vector2>().x;
    }

    void OnJump()
    {
        if(isTouchingGround)
        {
            rb.AddForceY(jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.collider.CompareTag("ground"))
        {
            isTouchingGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("ground"))
        {
            isTouchingGround = false;
        }
    }
}
