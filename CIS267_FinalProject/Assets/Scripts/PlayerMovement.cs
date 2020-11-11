using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    private Rigidbody2D playerRigidBody;
    private float moveHorizontal;
    public float jumpForce;
    public string midJump = "n";

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
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
    }

    private void flipPlayer(float input)
    {
        if(input > 0)
        {
            playerRigidBody.transform.localScale = new Vector3(1,1,1);
        }
        else if(input < 0)
        {
            playerRigidBody.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void jump()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && midJump == "n")
        {
            playerRigidBody.velocity = new Vector2(0, jumpForce);
            midJump = "y";
        }
        if (playerRigidBody.velocity.y == 0)
        {
            midJump = "n";
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.gameObject.CompareTag("OutOfBounds"))
        //{
        //    //Debug.Log("OB");
        //    SceneManager.LoadScene("SampleScene");
        //}
    }
}
