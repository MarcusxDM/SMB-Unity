using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    bool facingRight;
    public Rigidbody2D player;
    public Transform   t_player;
    [SerializeField] private float MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
    [SerializeField] private float JumpForce = 400f;                  // Amount of force added when the player jumps.
    [Range(0, 1)] [SerializeField] private float CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
    [SerializeField] private bool AirControl = false;                 // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask WhatIsGround;                  // A mask determining what is ground to the character
                                                                        // Use this for initialization
    void Start () {
        facingRight = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey("d"))
        {
            if (!facingRight)
            {
                Flip();
            }
            player.velocity = new Vector2(MaxSpeed, player.velocity.y);
        }

        if (Input.GetKey("a"))
        {
            if (facingRight)
            {
                Flip();
            }
            player.velocity = new Vector2(-MaxSpeed, player.velocity.y);
        }

        if (Input.GetKey("space"))
        {
            player.velocity = new Vector2(player.velocity.x, JumpForce);
        }

    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 aux = t_player.localScale;
        aux.x *= -1;
        t_player.localScale = aux;
    }
}
