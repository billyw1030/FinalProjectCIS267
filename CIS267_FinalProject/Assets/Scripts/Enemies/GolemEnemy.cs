using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemEnemy : MonoBehaviour
{
    // Start is called before the first frame update
   
    private Rigidbody2D GolemRigid;
    private Animator GolemAnim;
    private float timeStart = 0;
    private bool Startcount=false;
    private GameObject Arrow;
    public GameObject box;
    public AudioClip Fists;
    public AudioClip SDeath;
    private Rigidbody2D golemRigidBody;






    void Start()
    {
        GolemAnim = GetComponentInChildren<Animator>();
        GolemRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Startcount == true)
        {
            timeStart += Time.deltaTime;
            if(timeStart >= 1)
            {
                Destroy(Arrow, 6.0f);
                GolemAnim.SetBool("IsHit", false);
                Startcount = false;
                timeStart = 0;
                GetComponent<AudioSource>().PlayOneShot(Fists, 1);
                
            }



        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        
        if (collision.gameObject.CompareTag("Arrow"))
        {
            
            GolemAnim.SetBool("IsHit", true);
            //Destroy(collision.gameObject);
            Startcount = true;
            
            Arrow = collision.gameObject;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            GolemAnim.SetBool("IsHit", true);
            Startcount = true;

        }
        if (collision.gameObject.CompareTag("Box"))
        {
            Destroy(box);
            GolemAnim.SetBool("IsDead", true);
            this.gameObject.GetComponent<GolemEnemy>().enabled = false;
            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<AudioSource>().PlayOneShot(SDeath, 1);
            //Destroy(gameObject.GetComponent<BoxCollider2D>());



            Destroy(this.gameObject, 2.15f);
        }
    }

}
    


