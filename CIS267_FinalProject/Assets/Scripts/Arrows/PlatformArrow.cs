using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformArrow : MonoBehaviour
{
    public int destroyTimer;
    private bool isFrozen;
    // Start is called before the first frame update
    void Start()
    {
        isFrozen = false;
        Destroy(this.gameObject, destroyTimer);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D platformArrowCollision)
    {
        if (platformArrowCollision.gameObject.CompareTag("Wall") || platformArrowCollision.gameObject.CompareTag("Platform") || platformArrowCollision.gameObject.CompareTag("Ground"))
        {
            if (isFrozen == false)
            {
                this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                isFrozen = true;
            }
        }
        else if (platformArrowCollision.gameObject.CompareTag("Player") && isFrozen == false)
        {
            //do nothing
        }
        else if (isFrozen == false) 
        {
            Destroy(this.gameObject);
        }

    }


}
