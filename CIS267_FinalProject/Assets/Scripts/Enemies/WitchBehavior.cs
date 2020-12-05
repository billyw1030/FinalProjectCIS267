using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class WitchBehavior : MonoBehaviour
{
    //Objects
    public GameObject potion;

    //Options
    public float shortWanderDistance;
    public float longWanderDistance;
    public float maxWanderDistanceLeft;
    public float maxWanderDistanceRight;
    public float detectionDistance;
    public float movementSpeed;
    public float waitTime;
    public float attackTime;
    public float shootTime;
    public float potionVelocity;
    public float upwardVelocity;

    //Const
    private const float attackDistance = 1.25f;
    private const float potionXDifference = 0.1194587f;
    private const float potionYDifference = 0.0082588f;

    //Storing Info
    private float startingPosition;
    private float leftBoundary;
    private float rightBoundary;
    private GameObject player;
    private Rigidbody2D witchRigidBody;
    private Animator witchAnimator;
    private GameObject currentPotion;

    //Usage Variables
    private float currentPlayerDistance;
    private bool moving;
    private bool waiting;
    private float destination;
    private float direction;
    private float waitTimer;
    private bool isFacingRight;
    private bool isAlive;
    private bool attacking;
    private float attackTimer;
    private bool hasShot;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        witchRigidBody = this.gameObject.GetComponent<Rigidbody2D>();
        witchAnimator = this.gameObject.transform.GetChild(0).GetComponent<Animator>();
        startingPosition = this.gameObject.transform.position.x;
        leftBoundary = startingPosition - maxWanderDistanceLeft;
        rightBoundary = startingPosition + maxWanderDistanceRight;
        moving = false;
        isAlive = true;
        //This is important
        waitTimer = 0;
        attackTimer = 0;
        //Careful
        isFacingRight = false;
        attacking = false;
        hasShot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            if (!attacking)
            {
                witchAnimator.SetBool("isAttacking", false);
                currentPlayerDistance = getPlayerDistance();
                //Uses absolute value to determine actual distance
                if (Mathf.Abs(currentPlayerDistance) <= attackDistance)
                {
                    witchAnimator.SetBool("isWalking", false);
                    attack();
                }
                else if (Mathf.Abs(currentPlayerDistance) <= detectionDistance)
                {
                    moveToPlayer(currentPlayerDistance);
                }
                else
                {
                    wander();
                }
            }
            else
            {
                
                witchRigidBody.velocity = new Vector2(0f, witchRigidBody.velocity.y);
                attackTimer += Time.deltaTime;
                if(!hasShot && attackTimer >= shootTime)
                {
                    currentPotion = Instantiate(potion);

                    if (isFacingRight)
                    {
                        currentPotion.transform.position = new Vector3(this.gameObject.transform.position.x - potionXDifference, this.gameObject.transform.position.y - potionYDifference);
                        currentPotion.GetComponent<Rigidbody2D>().velocity = new Vector3(potionVelocity, upwardVelocity, 0);
                    }
                    else
                    {
                        currentPotion.transform.position = new Vector3(this.gameObject.transform.position.x + potionXDifference, this.gameObject.transform.position.y - potionYDifference);
                        currentPotion.transform.localScale = new Vector3(-currentPotion.transform.localScale.x, currentPotion.transform.localScale.y, currentPotion.transform.localScale.z);
                        currentPotion.GetComponent<Rigidbody2D>().velocity = new Vector3(-potionVelocity, upwardVelocity, 0);
                    }

                    hasShot = true;
                }
                if(attackTimer >= attackTime)
                {
                    attacking = false;
                    witchAnimator.SetBool("isAttacking", false);
                    attackTimer = 0;
                }
                
            }
        }
    }

    private void wander()
    {
        if (moving)
        {
            if (direction > 0)
            {
                if (isFacingRight == false)
                {
                    //Moving Right 
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    isFacingRight = true;
                }

                //Right
                if (this.gameObject.transform.position.x < rightBoundary)
                {
                    if (this.gameObject.transform.position.x < destination)
                    {
                        witchAnimator.SetBool("isWalking", true);
                        witchRigidBody.velocity = new Vector2(movementSpeed, witchRigidBody.velocity.y);
                    }
                    else
                    {
                        witchAnimator.SetBool("isWalking",false);
                        waiting = true;
                        moving = false;
                        //Just in case
                        destination = startingPosition;
                        direction = 0;
                        witchRigidBody.velocity = new Vector2(0, witchRigidBody.velocity.y);
                    }
                }
                else
                {
                    //You've gone too far right
                    witchAnimator.SetBool("isWalking",false);
                    waiting = true;
                    moving = false;
                    //Just in case
                    destination = startingPosition;
                    direction = 0;
                    witchRigidBody.velocity = new Vector2(0, witchRigidBody.velocity.y);
                }
            }
            else if (direction < 0)
            {
                //Left

                if (isFacingRight == true)
                {
                    //Moving Right 
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    isFacingRight = false;
                }

                if (this.gameObject.transform.position.x > leftBoundary + shortWanderDistance / 4)
                {
                    if (this.gameObject.transform.position.x > destination)
                    {
                        witchRigidBody.velocity = new Vector2(-movementSpeed, witchRigidBody.velocity.y);
                        witchAnimator.SetBool("isWalking",true);
                    }
                    else
                    {
                        witchAnimator.SetBool("isWalking",false);
                        waiting = true;
                        moving = false;
                        //Just in case
                        destination = startingPosition;
                        direction = 0;
                        witchRigidBody.velocity = new Vector2(0, witchRigidBody.velocity.y);
                    }
                }
                else
                {
                    //You've gone too far left
                    witchAnimator.SetBool("isWalking",false);
                    waiting = true;
                    moving = false;
                    //Just in case
                    destination = startingPosition;
                    direction = 0;
                    witchRigidBody.velocity = new Vector2(0, witchRigidBody.velocity.y);
                }
            }
            else
            {
                //Something went Wrong
                witchAnimator.SetBool("isWalking",false);
                moving = false;
                witchRigidBody.velocity = new Vector2(0, witchRigidBody.velocity.y);
            }

        }
        else if (waiting)
        {
            witchAnimator.SetBool("isWalking",false);
 
            waitTimer += Time.deltaTime;

            if (waitTimer >= waitTime)
            {
                waiting = false;
                waitTimer = 0;
            }
        }
        else
        {
            //Select new action


            int randNum = Random.Range(1, 7);

            if (randNum <= 2)
            {
                //wait
                waiting = true;
            }
            else if (randNum == 3)
            {
                //short wander left
                moving = true;
                destination = this.gameObject.transform.position.x - shortWanderDistance;
                direction = -1;
            }
            else if (randNum == 4)
            {
                //short wander right
                moving = true;
                destination = this.gameObject.transform.position.x + shortWanderDistance;
                direction = 1;
            }
            else if (randNum == 5)
            {
                //long wander left
                moving = true;
                destination = this.gameObject.transform.position.x - longWanderDistance;
                direction = -1;
            }
            else if (randNum == 6)
            {
                //long wander right
                moving = true;
                destination = this.gameObject.transform.position.x + longWanderDistance;
                direction = 1;
            }

        }
    }

    private float getPlayerDistance()
    {
        float calculateDistance = player.transform.position.x - this.gameObject.transform.position.x;

        return calculateDistance;
    }

    private void moveToPlayer(float d)
    {

        if(player.transform.position.x > this.gameObject.transform.position.x)
        {
            if (this.gameObject.transform.position.x < rightBoundary)
            {
                if (isFacingRight == false)
                {
                    //Moving Right 
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    isFacingRight = true;
                }
                witchRigidBody.velocity = new Vector2(movementSpeed, witchRigidBody.velocity.y);
                witchAnimator.SetBool("isWalking",true);
            }
            else
            {
                witchAnimator.SetBool("isWalking",false);
                witchRigidBody.velocity = new Vector2(0, witchRigidBody.velocity.y);
            }
        }
        else
        {
            if (this.gameObject.transform.position.x > leftBoundary)
            {
                if (isFacingRight == true)
                {
                    //Moving Right 
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    isFacingRight = false;
                }
                witchRigidBody.velocity = new Vector2(-movementSpeed, witchRigidBody.velocity.y);
                witchAnimator.SetBool("isWalking",true);
            }
            else
            {
                witchAnimator.SetBool("isWalking",false);
                witchRigidBody.velocity = new Vector2(0, witchRigidBody.velocity.y);
            }
        }
    }

    private void flipSprite(float d)
    {
        if (d > 0 && isFacingRight == false)
        {
            //Moving Right 
            transform.eulerAngles = new Vector3(0, 0, 0);
            isFacingRight = true;
        }
        else if (d < 0 && isFacingRight == true)
        {
            //Moving Left 
            transform.eulerAngles = new Vector3(0, 180, 0);
            isFacingRight = false;
        }
    }


    //Temporary test for witch animations/textures. Most likely no longer needed
    /*
    private void updateSprite()
    {
        if(witchRigidBody.velocity.x == 0)
        {

        }
        else if (witchRigidBody.velocity.x > 0.01 && isFacingRight == false)
        {
            //Moving Right 
            transform.eulerAngles = new Vector3(0, 0, 0);
            isFacingRight = true;
        }
        else if (witchRigidBody.velocity.x < 0.01 && isFacingRight == true)
        {
            //Moving Left 
            transform.eulerAngles = new Vector3(0, 180, 0);
            isFacingRight = false;
        }

        //Temp code, most likely won't need again
      
        if(witchRigidBody.velocity.x > 0 || witchRigidBody.velocity.x < 0)
        {
            witchAnimator.SetBool("isWalking", true);
        }
        else
        {
            witchAnimator.SetBool("isWalking", false);
        }
     
    }
    */


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Arrow") || collision.gameObject.CompareTag("PlatformArrow") || collision.gameObject.CompareTag("ZiplineArrow") || collision.gameObject.CompareTag("FireArrow"))
        {
            witchRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            isAlive = false;
            witchRigidBody.velocity = new Vector2(0, witchRigidBody.velocity.y);
            moving = false;
            waiting = false;
            waitTimer = 0;
            witchAnimator.SetBool("isDead", true);
        }
        else if(collision.gameObject.CompareTag("WitchEnemy"))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), this.gameObject.GetComponent<BoxCollider2D>());
        }
        else
        {
            //Reset
            witchAnimator.SetBool("isWalking", false);
            waiting = true;
            moving = false;
            //Just in case
            destination = startingPosition;
            direction = 0;
            witchRigidBody.velocity = new Vector2(0, witchRigidBody.velocity.y);
        }

    }

    private void attack()
    {
        witchAnimator.SetBool("isAttacking", true);
        attacking = true;
        witchRigidBody.velocity = new Vector2(0, witchRigidBody.velocity.y);
        moving = false;
        waiting = false;
        waitTimer = 0;
        hasShot = false;

        if(player.transform.position.x <= this.gameObject.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            isFacingRight = false;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            isFacingRight = true;
        }
    }
}
