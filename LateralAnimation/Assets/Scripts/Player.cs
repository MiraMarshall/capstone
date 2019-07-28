using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

// Must do's:

// Bullets, Questions,
// End to end for a level - transitions
// Start menu
// Hit the enemies

// Look for completed code

    // success finding resources, being able to get an MVP
    // struggles time, finding/ making sprites
    

public class Player : MonoBehaviour
{
    // Configurations
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(20f, 20f);
    [SerializeField] GameObject laser;
    [SerializeField] float projectileSpeed = 10f;
    //State
    bool isAlive = true;

    // Cached component references

    Rigidbody2D myRigidBody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeet;
    // Messages then methods 

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
    
    }

    // Update is called once per frame
    void Update()
    {
        //stops ability to move
        if (!isAlive) { return; }

        Run();
        Jump();
        FlipSprite();
        Die();
        Fire();
    }

    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // value is between -1 and 1
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", playerHasHorizontalSpeed);
        //Go to running state if player is moving horizontally.  
    }

    private void Jump()
    {
        if(!myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))){ return;}

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity += jumpVelocityToAdd;

        }
    }

    private void FlipSprite()
    {
        // if the player is moving horizontially
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
            //reverse the current scalling of the x axis
        }
    }

    private void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
           {
            isAlive = false;

            myAnimator.SetTrigger("Dying");
            GetComponent<Rigidbody2D>().velocity = deathKick;
           }
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject fireLaser = Instantiate(
                laser,
                transform.position,
                Quaternion.identity) as GameObject;
            fireLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);

        }
    }
  
}
