using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZiplineArrow : MonoBehaviour
{
    public GameObject chain;
    public GameObject arrow;
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
                GameObject c = Instantiate(chain) as GameObject;
                clock = 0;
                //c.transform.position = arrow.position;
            }
        }

    }
    

}
