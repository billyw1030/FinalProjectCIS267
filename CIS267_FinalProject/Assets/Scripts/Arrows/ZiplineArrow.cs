using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZiplineArrow : MonoBehaviour
{
    public GameObject chain;
    public GameObject arrow;
    public GameObject Player;
    public float clock;
    public bool startcount;
    public float waitTime;
    
    // Start is called before the first frame update
    void Start()
    {
        clock = 0;

        startcount = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (startcount)
        {
            clock += Time.deltaTime;

            if (clock >= waitTime)
            {
                clock = 0;
                Destroy(this.gameObject);

            }
        }
        

    }
    private void OnCollisionEnter2D(Collision2D ziplineCollision)
    {
        if(ziplineCollision.gameObject.CompareTag("Ground" /*"endline"*/))
        {
            Debug.Log("Grapple");
            Player.transform.position = ziplineCollision.gameObject.transform.position; //maybe try putting Player.gameObject.transform.position? Im not sure, this would technically teleport you to a point where the arrow lands
            Destroy(this.gameObject);

        }
        else if (!ziplineCollision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }



}
