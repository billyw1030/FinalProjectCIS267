using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerMan : MonoBehaviour
{
    public AudioClip HammerHit;
    public AudioClip HammerDeath;
    public AudioClip Swing1;
    private int hammerHealth = 2;
    private float speed = 0.5f;
    private Transform target;
    private Rigidbody2D enemyRigidBody;
    //private SpriteRenderer enemySprite;
    //public Transform playerCharacter;
    //public GameObject MainSprite;
    private GameObject player;
    private Animator HammerAnim;
    private int num;
    private float distance;
    private float attackRange = 1.0f;
    public float farthestSpotPlayer = 3f;
    

    //private float cnt = 0f;

    private bool isAlive;
    //private bool isAttacking;

    private void Start()
    {
        isAlive = true;
        //isAttacking = false;
        //this.enemySprite = this.GetComponent<SpriteRenderer>();
        //HammerAnim = transform.Find("HammerManTest").GetComponent<Animator>();
        //HammerAnim = MainSprite.GetComponent<Animator>();
        HammerAnim = GetComponentInChildren<Animator>();
        enemyRigidBody = this.gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (isAlive)
        {
            distance = getPlayerDistance();
            if (distance >= 0.1 && distance <= farthestSpotPlayer)
            {
                //Debug.Log("Chasing from Left");
                HammerAnim.SetTrigger("TriggerIsWalking");
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
                //enemyRigidBody.transform.localScale = new Vector3(-1, 1, 1);
                this.gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;

                if (Mathf.Abs(distance) <= attackRange)
                {
                    //Debug.Log("Time To Attack!");
                    HammerAnim.ResetTrigger("TriggerIsWalking");
                    HammerAnim.SetTrigger("TriggerTimeToAttack");
                    
                }
            }
            else if (distance <= -0.1 && distance >= -1 * farthestSpotPlayer)
            {
                //Debug.Log("Chasing from Right");
                HammerAnim.SetTrigger("TriggerIsWalking");
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * -1, 0);
                //enemyRigidBody.transform.localScale = new Vector3(-1, 1, 1);
                this.gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;

                if (Mathf.Abs(distance) <= attackRange)
                {
                    //Debug.Log("Time to Attack part 2!");
                    HammerAnim.ResetTrigger("TriggerIsWalking");
                    HammerAnim.SetTrigger("TriggerTimeToAttack");
                    //GetComponent<AudioSource>().PlayOneShot(Swing1, 1);
                }
            }
            else
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }

            
        }
    }


    private void OnCollisionEnter2D(Collision2D HammerManCollisions)
    {
        if(HammerManCollisions.gameObject.CompareTag("Arrow"))
        {
            Destroy(HammerManCollisions.gameObject);
            hammerHealth = hammerHealth - 1;
            if(hammerHealth == 1)
            {
                GetComponent<AudioSource>().PlayOneShot(HammerHit, 1);
            }
            if(hammerHealth == 0)
            {
                HammerAnim.ResetTrigger("TriggerIsWalking");
                HammerAnim.ResetTrigger("TriggerTimeToAttack");
                HammerAnim.SetTrigger("TriggerIsDead");
                this.gameObject.GetComponent<HammerMan>().enabled = false;
                this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                //Destroy(GetComponent<BoxCollider2D>());
                GetComponent<AudioSource>().PlayOneShot(HammerDeath, 1);
                Destroy(this.gameObject, 3);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("FallingTree"))
        {
                HammerAnim.ResetTrigger("TriggerIsWalking");
                HammerAnim.ResetTrigger("TriggerTimeToAttack");
                HammerAnim.SetTrigger("TriggerIsDead");
                GetComponent<AudioSource>().PlayOneShot(HammerDeath, 1);
                Destroy(GetComponent<BoxCollider2D>());
                Destroy(this.gameObject, 3);
        }
    }

    private float getPlayerDistance()
    {
        float calculateDistance = player.transform.position.x - this.gameObject.transform.position.x;

        return calculateDistance;
    }
}


//IGNORE

//if (Vector2.Distance(this.transform.position, player.transform.position) > .2)
//{
//    Debug.Log("Im further than .2");
//    this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

//    if (this.gameObject.GetComponent<Rigidbody2D>().velocity.x < 0)
//    {
//        HammerAnim.SetBool("IsWalking", true);
//        //enemyRigidBody.transform.localScale = new Vector3(-1, 1, 1);
//        this.gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
//    }
//    else if (this.gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
//    {
//        HammerAnim.SetBool("IsWalking", true);
//        //enemyRigidBody.transform.localScale = new Vector3(1, 1, 1);
//        this.gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
//    }
//}
//else if (Vector2.Distance(this.transform.position, player.transform.position) < .3)
//{
//    Debug.Log("Im less than .5");
//    HammerAnim.SetBool("IsWalking", false);
//    num = Random.Range(1, 3);
//    if (num == 1)
//    {
//        Debug.Log("FirstAttack");
//        HammerAnim.SetBool("TimeToAttack", true);
//    }
//    else if (num == 2)
//    {
//        Debug.Log("SecondAttack");
//        HammerAnim.SetBool("TimeToSpin", true);
//    }


//}