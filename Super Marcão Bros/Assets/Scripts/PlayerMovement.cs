using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    
    private Rigidbody2D player;
    public Transform   t_player;
    public Animator    animator;
    [SerializeField] private float MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
    [SerializeField] private float JumpForce = 400f;                  // Amount of force added when the player jumps.
    [Range(0, 1)] [SerializeField] private float CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
    [SerializeField] private bool AirControl = false;                 // Whether or not a player can steer while jumping;
    public Transform groundCheck; //Check if the character is on ground
    [SerializeField] private LayerMask whatIsGround;         // A mask determining what is ground to the character  

    bool facingRight;
    bool grounded;  // Is in ground
    float groundRadius = 0.2f;    //How big is gonna be the radius of ground checking point
    int jumping;
    bool walking;
    // Use this for initialization
    void Start () {
        player = GetComponent<Rigidbody2D>();
        facingRight = true;
        grounded = false;
	}

    private void Update()
    {
        walking = player.velocity.x != 0; //Checks if player is walking
        if (player.velocity.y == 0)
        {
            jumping = 0;
        }
        else if (player.velocity.y > 0)
        {
            jumping = 1;
        }
        else
        {
            jumping = 2;
        }

        animator.SetBool("walking", walking);
        animator.SetInteger("jumping", jumping);
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (grounded)
        {
            animator.SetInteger("jumping", 0);
        }
        // Check if player is grounded
        grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                grounded = true;
        }
        if (Input.GetKey("a"))
        {
            if (facingRight)
            {
                Flip();
            }
            player.velocity = new Vector2(-MaxSpeed, player.velocity.y);
        }
        if (Input.GetKey("d"))
        {
            if (!facingRight)
            {
                Flip();
            }
            player.velocity = new Vector2(MaxSpeed, player.velocity.y);
        }
        if (Input.GetKey("space"))
        {
            if (grounded)
            {
                Jump();
            }
        }

    }

    void Jump()
    {
        animator.SetInteger("jumping", 1);
        player.velocity = new Vector2(player.velocity.x, JumpForce);
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 aux = t_player.localScale;
        aux.x *= -1;
        t_player.localScale = aux;
    }
}
