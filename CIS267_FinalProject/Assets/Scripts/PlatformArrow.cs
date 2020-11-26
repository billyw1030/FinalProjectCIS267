using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformArrow : MonoBehaviour
{
    public int destroyTimer;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, destroyTimer);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D platformArrowCollision)
    {
        if (gameObject.CompareTag("Wall") || gameObject.CompareTag("Platform") || gameObject.CompareTag("Ground"))
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }
        else if(gameObject.CompareTag("Player"))
        {
            //do nothing
        }
        else 
        {
            Destroy(this.gameObject);
        }

    }


}
