using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeBox : MonoBehaviour
{
    public GameObject myBox;
    public float dropTime;

    private bool boxFreeze;
    private float boxTimer;



    // Start is called before the first frame update
    void Start()
    {
        boxTimer = 0;
        boxFreeze = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(boxFreeze)
        {
            boxTimer += Time.deltaTime;

            if(boxTimer >= dropTime)
            {
                myBox.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
                boxFreeze = false;
                boxTimer = 0;
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Arrow"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            myBox.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            boxFreeze = true;

        }
    }
}
