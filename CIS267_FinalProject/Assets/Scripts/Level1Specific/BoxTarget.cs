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

    private void OnTriggerEnter2D(Collider2D boxDrop)
    {
        if(boxDrop.gameObject.CompareTag("Arrow"))
        {
            Destroy(this.gameObject);
            box.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
    }
}
