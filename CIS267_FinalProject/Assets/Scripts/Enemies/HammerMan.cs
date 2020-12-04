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
    private Animator HammerAnim;

    private void Start()
    {
        //this.enemySprite = this.GetComponent<SpriteRenderer>();
        //HammerAnim = transform.Find("HammerManTest").GetComponent<Animator>();
        HammerAnim = MainSprite.GetComponent<Animator>();
        enemyRigidBody = gameObject.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = 0.5f;


        if (Vector2.Distance(transform.position, target.position) > .5)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if (this.gameObject.GetComponent<Rigidbody>().velocity.x < 0)
            {
                HammerAnim.SetBool("IsWalking", true);
                enemyRigidBody.transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (this.gameObject.GetComponent<Rigidbody>().velocity.x > 0)
            {
                HammerAnim.SetBool("IsWalking", true);
                enemyRigidBody.transform.localScale = new Vector3(1, 1, 1);
            }
        }
        HammerAnim.SetBool("IsWalking", false);

        if(Vector2.Distance(transform.position, target.position) < 1)
        {
            HammerAnim.SetBool("TimeToAttack", true);
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
                Destroy(GetComponent<BoxCollider2D>());
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
