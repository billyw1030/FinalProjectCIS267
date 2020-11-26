using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootJumpColliders : MonoBehaviour
{
    //stored values
    private float objectsCollided;

    // Start is called before the first frame update
    void Start()
    {
        objectsCollided = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool getIsGrounded()
    {
        if(objectsCollided > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Collisions

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("PlatformArrow"))
        {
                objectsCollided++;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("PlatformArrow"))
        {
            if (objectsCollided > 0)
            {
                objectsCollided--;
            }
        }
    }
}
