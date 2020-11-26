using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("BlastZone"))
        {
            this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x, 2.4f);
        }
    }
}
