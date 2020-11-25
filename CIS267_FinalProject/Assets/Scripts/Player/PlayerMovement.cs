using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    private Rigidbody2D playerRigidBody;
    private float moveHorizontal;
    public float jumpForce;
    public string midJump = "n";
    private Animator playerSpriteAnimator;

    bool isFacingRight;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerSpriteAnimator = this.gameObject.transform.GetChild(0).GetComponent<Animator>();
        isFacingRight = true; //Watch Out!
    }

    void Update()
    {
        movePlayerLateral();
        jump();
    }

    private void movePlayerLateral()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        playerRigidBody.velocity = new Vector2(movementSpeed * moveHorizontal, playerRigidBody.velocity.y);

        flipPlayer(moveHorizontal);

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

    private void flipPlayer(float input)
    {
        if(input > 0)
        {
            playerRigidBody.transform.localScale = new Vector3(1,1,1);
            isFacingRight = true;
        }
        else if(input < 0)
        {
            playerRigidBody.transform.localScale = new Vector3(-1, 1, 1);
            isFacingRight = false;
        }
    }

    private void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && midJump == "n")
        {
            playerRigidBody.velocity = new Vector2(0, jumpForce);
            midJump = "y";
        }
        if (playerRigidBody.velocity.y == 0)
        {
            midJump = "n";
        }

    }

    public bool getIsFacingRight()
    {
        return isFacingRight;
    }

}
