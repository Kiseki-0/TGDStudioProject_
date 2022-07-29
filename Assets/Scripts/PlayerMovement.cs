using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;

    
    [SerializeField] private float playerSpeed = 8f;
    [SerializeField] private float jumpForce = 20f;

    private enum MovementState { idle, running, jumping, falling }
    

    // Start => ready() do godot
    // println do unity, c# => Debug.Log("Hello, world!");
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // acesse rigidbody apenas 1x, mais eficiente
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal"); // get axis raw = no sliding
        rb.velocity = new Vector2(dirX * playerSpeed, rb.velocity.y);
        
        // Se espaço foi pressionado, pule
        // Get key checa se está pressionada, e keydown só uma vez (ativa novamente no release).
        // get button vai pro input map da unity, mais eficiente
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // aplicando velocidade no rigid body
        }

        UpdateAnimationState();
    }

    

    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f) //jump check
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
