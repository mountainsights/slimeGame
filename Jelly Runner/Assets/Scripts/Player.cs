using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
    [SerializeField] float runSpeed = 6f;
    [SerializeField] float jumpSpeed = 10f;
    [SerializeField] float flyStrength = 10f; //Currently no in use

    Rigidbody2D myRigidbody;
    BoxCollider2D myFeet;
    BoxCollider2D outerCollider;

    // Use this for initialization
    void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        myFeet = GetComponent<BoxCollider2D>();
        outerCollider = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Run(); //Moves character horizontally
        flipSprite(); //flips the sprite to match direction of movement
        Jump();
	}

    private void Jump()
    {
        /*
        float controlJump = CrossPlatformInputManager.GetAxis("Vertical"); // Gets the vertical component
        Vector2 playerJump = new Vector2(myRigidbody.velocity.x, controlJump * flyStrength);
        myRigidbody.velocity = playerJump; 
        */

        //Useful for flying mechanic

        if(!myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))) //Checks to see if player is touching the ground to jump
        {
            return; 
        }

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
            myRigidbody.velocity += jumpVelocity;
            
        }
    }

    public void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); //Gets the axis (Horizontal component)
        Vector2 playerVelocity = new Vector2(controlThrow* runSpeed, myRigidbody.velocity.y); //Create a vector2
        myRigidbody.velocity = playerVelocity; //Velocity of the player will be playerVelocity
        print(controlThrow);

        //TODO: Add running animation 
    }

    private void flipSprite()
    {
        bool isPlayerMoving = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon; 
        if (isPlayerMoving == true)
        {
            transform.localScale = new Vector2(-Mathf.Sign(myRigidbody.velocity.x), 1f);
           
        }


    }
}
