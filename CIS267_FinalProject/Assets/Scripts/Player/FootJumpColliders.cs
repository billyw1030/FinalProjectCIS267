using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Temp
using UnityEngine.SceneManagement;

public class FootJumpColliders : MonoBehaviour
{
    //stored values
    private float objectsCollided;

    //Objects
    private Animator playerSpriteAnimator;
    private MainGameManagerScript gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        objectsCollided = 0;
        playerSpriteAnimator = this.gameObject.transform.parent.gameObject.transform.GetChild(0).GetComponent<Animator>();

        try
        {
            gameManagerScript = GameObject.Find("GameManager").GetComponent<MainGameManagerScript>();
        }
        catch
        {
            Debug.Log("Cannot Find GameManager");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool getIsGrounded()
    {
        if(objectsCollided > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Collisions

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Animations
        if(objectsCollided <= 0)
        {
            playerSpriteAnimator.SetBool("isJumping", false);
        }

        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("PlatformArrow") || collision.gameObject.CompareTag("Box"))
        {
                objectsCollided++;
        }
        else if (collision.gameObject.CompareTag("BlastZone"))
        {
            //TEMPORARY
            //this.gameObject.transform.parent.gameObject.transform.position = new Vector2(0.3f, -0.8f);

            try
            {
                gameManagerScript.playerDeath();
            }
            catch
            {
                //for testing
                Debug.Log("UNABLE TO FIND GAME MANAGER");
                this.gameObject.transform.parent.gameObject.transform.position = new Vector2(0.3f, -0.8f);
            }

        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("PlatformArrow"))
        {
            if (objectsCollided > 0)
            {
                objectsCollided--;
            }
        }

        //Animations
        if (objectsCollided <= 0)
        {
            playerSpriteAnimator.SetBool("isJumping", true);
        }
    }


    public void setObjectsCollided(float o)
    {
        objectsCollided = o;
    }
}
