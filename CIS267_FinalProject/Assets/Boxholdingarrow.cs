using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxholdingarrow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D boxCollision)
    {
        if (boxCollision.gameObject.CompareTag("Arrow"))
        {
            Destroy(this.gameObject);

        }
    }

}
