using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerMan : MonoBehaviour
{
    private int hammerHealth = 2;
    private float speed;
    private Transform target;
    private Rigidbody2D enemyRigidBody;
    //private SpriteRenderer enemySprite;
    //public Transform playerCharacter;
    public GameObject MainSprite;
    public GameObject player;
    private Animator HammerAnim;
    private int num;

    private void Start()
    {
        //this.enemySprite = this.GetComponent<SpriteRenderer>();
        //HammerAnim = transform.Find("HammerManTest").GetComponent<Animator>();
        //HammerAnim = MainSprite.GetComponent<Animator>();
        HammerAnim = GetComponentInChildren<Animator>();
        enemyRigidBody = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = 0.5f;


        if (Vector2.Distance(this.transform.position, player.transform.position) > .2)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

            if (this.gameObject.GetComponent<Rigidbody2D>().velocity.x < 0)
            {
                HammerAnim.SetBool("IsWalking", true);
                //enemyRigidBody.transform.localScale = new Vector3(-1, 1, 1);
                this.gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
            }
            else if (this.gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
            {
                HammerAnim.SetBool("IsWalking", true);
                //enemyRigidBody.transform.localScale = new Vector3(1, 1, 1);
                this.gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
            }
        }
        HammerAnim.SetBool("IsWalking", false);

        if(Vector2.Distance(this.transform.position, player.transform.position) < .5)
        {
            num = Random.Range(1, 2);
            if (num == 1)
            {
                HammerAnim.SetBool("TimeToAttack", true);
            }
            else if (num == 2)
            {
                HammerAnim.SetBool("TimeToSpin", true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D HammerManCollisions)
    {
        if(HammerManCollisions.gameObject.CompareTag("Arrow"))
        {
            Destroy(HammerManCollisions.gameObject);
            hammerHealth = hammerHealth - 1;

            if(hammerHealth == 0)
            {
                HammerAnim.SetBool("IsDead", true);
                //Destroy(GetComponent<BoxCollider2D>());
                Destroy(this.gameObject, 3);
            }
        }
        if(HammerManCollisions.gameObject.CompareTag("FallingTree"))
        {
            HammerAnim.SetBool("IsDead", true);
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(this.gameObject, 3);
        }
    }

}
