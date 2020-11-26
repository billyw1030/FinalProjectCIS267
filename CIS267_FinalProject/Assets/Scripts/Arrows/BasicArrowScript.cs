using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicArrowScript : MonoBehaviour
{
    private float clock;
    public float waitTime;
    private bool startClock;
    // Start is called before the first frame update
    void Start()
    {
        clock = 0;
        startClock = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(startClock)
        {
            clock += Time.deltaTime;

            if(clock >= waitTime)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Player"))
        {
            startClock = true;
        }
    }
}
