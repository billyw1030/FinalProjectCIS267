using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTarget : MonoBehaviour
{
    public GameObject box;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D boxDrop)
    {
        if(boxDrop.gameObject.CompareTag("Arrow") || boxDrop.gameObject.CompareTag("FireArrow"))
        {
            Destroy(this.gameObject);
            box.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
    }
}
