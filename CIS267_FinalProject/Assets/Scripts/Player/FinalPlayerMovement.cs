using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPlayerMovement : MonoBehaviour
{
    //Public Values
    public float movementSpeed;
    public float fallMultiplier;
    public float lowJumpMultiplier;
    public float jumpForce;
    public float shootSlowDown;
    public AudioClip JumpSound;

    //Components
    private Rigidbody2D playerRigidBody;
    private Animator playerSpriteAnimator;
    private FootJumpColliders jumpColliderScript;

    //State Values values
    private float moveHorizontal;

    private bool isFacingRight;
    private float objectsCollided;
    private bool isSlowed;

    //Key Codes
    KeyCode jumpKey = KeyCode.Space;


    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerSpriteAnimator = this.gameObject.transform.GetChild(0).GetComponent<Animator>();
        jumpColliderScript = this.gameObject.transform.GetChild(1).GetComponent<FootJumpColliders>();

        isSlowed = false;
        isFacingRight = true; //Watch Out!

        //Ignore the feet collisions
        Physics2D.IgnoreCollision(this.gameObject.GetComponent<BoxCollider2D>(), this.gameObject.transform.GetChild(1).GetComponent<BoxCollider2D>());
    }

    void Update()
    {
        movePlayerLateral();
        changeDirection();
        jump();
        advancedJump(); //Modifies (and requires) jump to feel better
    }

    private void changeDirection()
    {
        if (Input.GetKeyDown(KeyCode.Q) && isFacingRight)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            isFacingRight = false;
        }
        else if (Input.GetKeyDown(KeyCode.E) && !isFacingRight)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            isFacingRight = true;
        }
    }
    private void movePlayerLateral()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        if (isSlowed)
        {
            playerRigidBody.velocity = new Vector2(movementSpeed * moveHorizontal * shootSlowDown, playerRigidBody.velocity.y);
        }
        else
        {
            playerRigidBody.velocity = new Vector2(movementSpeed * moveHorizontal, playerRigidBody.velocity.y);
        }

        playerDirection(moveHorizontal);

        //Animations
        if(moveHorizontal != 0)
        {
            playerSpriteAnimator.SetBool("isRunning", true);

        }
        else
        {
            playerSpriteAnimator.SetBool("isRunning", false);
        }
    }

    private void playerDirection(float horizontalDirection)
    {

        if (horizontalDirection > 0 && isFacingRight == false)
        {
            //Moving Right 
            transform.eulerAngles = new Vector3(0, 0, 0);
            isFacingRight = true;
        }
        else if (horizontalDirection < 0 && isFacingRight == true)
        {
            //Moving Left 
            transform.eulerAngles = new Vector3(0, 180, 0);
            isFacingRight = false;
        }

    }

    private void jump()
    {
        if(Input.GetKeyDown(jumpKey) && jumpColliderScript.getIsGrounded())
        {
            jumpColliderScript.setObjectsCollided(0);
            playerRigidBody.velocity = new Vector2(0, jumpForce);
            GetComponent<AudioSource>().PlayOneShot(JumpSound, 1);
        }

    }



    //Modifies (and requires) jump to feel better
    private void advancedJump()
    {
        //Snap Effect or small jump
        if(playerRigidBody.velocity.y < 0f)
        {
            playerRigidBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

        }
        else if(playerRigidBody.velocity.y > 0 && !Input.GetKey(jumpKey))
        {
            playerRigidBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }


    //Getters and Setters
    public bool getIsFacingRight()
    {
        return isFacingRight;
    }

    public void setIsSlowed(bool s)
    {
        isSlowed = s;
    }

}
