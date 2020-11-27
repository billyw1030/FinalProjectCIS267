using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZiplineArrow : MonoBehaviour
{
    public GameObject chain;
    public GameObject arrow;
    public GameObject Player;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        //clock = 0;

        //startcount = false;
        

        
    }

    // Update is called once per frame
    void Update()
    {
       // if (startcount)
        //{
            //clock += Time.deltaTime;

           // if (clock >= waitTime)
           // {
             //   clock = 0;
             //   Destroy(this.gameObject);

            //}
       //}
        

    }
    private void OnCollisionEnter2D(Collision2D ziplineCollision)
    {
        if(ziplineCollision.gameObject.CompareTag("Ground" /*"endline"*/))
        {
            Debug.Log("Grapple");
            Player.gameObject.transform.position = arrow.gameObject.transform.position;
            Debug.Log("Player moved");
            Destroy(this.gameObject);



        }
        else if (!ziplineCollision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }




}
