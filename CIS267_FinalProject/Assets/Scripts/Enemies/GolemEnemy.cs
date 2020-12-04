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
    public GameObject enemy;



    void Start()
    {
        GolemAnim = GameObject.Find("GolemSprite").GetComponent<Animator>();
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
                GolemAnim.SetBool("IsHit", false);
                Startcount = false;
                timeStart = 0;
                Destroy(Arrow);
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
        if (collision.gameObject.CompareTag("Box"))
        {
            Destroy(box);
            Destroy(enemy);
        }
    }

}
    


