using System;
using System.Collections;
using UnityEngine;

public class PlatformerCharacter2D : MonoBehaviour {
    [SerializeField]
    private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
    [SerializeField]
    private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
    [Range(0, 1)]
    [SerializeField]
    private float m_CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
    [SerializeField]
    private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
    [SerializeField]
    private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

    private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded.
    private Transform m_CeilingCheck;   // A position marking where to check for ceilings
    const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
    private Animator m_Anim;            // Reference to the player's animator component.
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.

    private void Awake() {
        // Setting up references.
        m_GroundCheck = transform.Find("GroundCheck");
        m_CeilingCheck = transform.Find("CeilingCheck");
        m_Anim = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate() {
        //m_Grounded = false;

        //// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        //// This can be done using layers instead but Sample Assets will not overwrite your project settings.
        //Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        //for (int i = 0; i < colliders.Length; i++)
        //{
        //    if (colliders[i].gameObject != gameObject)
        //        m_Grounded = true;
        //}
        //m_Anim.SetBool("Ground", m_Grounded);

        //// Set the vertical animation
        //m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
    }


    public void Move(float move, float moveUp) {
        // If crouching, check to see if the character can stand up


        //only control the player if grounded or airControl is turned on
        if (!(m_Anim.GetBool("defend")) && !(m_Anim.GetBool("attack"))) {
            if (move != 0) {
                m_Anim.Play("WalkRight");
            } //else if (move < 0) {
               // m_Anim.Play("WalkLeft");
            //} 
              else if (moveUp > 0) {
                m_Anim.Play("WalkUp");
            } else if (moveUp < 0) {
                m_Anim.Play("WalkDown");
            }
            m_Anim.SetFloat("move", move + moveUp);
        }
        // Move the character
        m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, moveUp * m_MaxSpeed);

        // If the input is moving the player right and the player is facing left...
        if (move > 0 && !m_FacingRight) {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && m_FacingRight) {
            // ... flip the player.
              Flip();
              
        } else {
            // m_Anim.Stop();
        }

    }
    private IEnumerator WaitForAnimation(Animation animation) {
        do {
            yield return null;
        } while (animation.isPlaying);
    }
    public void Attack(bool attack) {
        m_Anim.SetBool("attack", attack);
    }
    public void Defend(bool defend) {
        m_Anim.SetBool("defend", defend);
    }

    private void Flip() {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        FlipBack(GameObject.Find("UI"));

    }
    private void FlipBack(GameObject UIstuff) {
                // Multiply the player's x local scale by -1.
                Vector3 theScale = UIstuff.transform.localScale;
                theScale.x *= -1;
                UIstuff.transform.localScale = theScale;
            }
}
