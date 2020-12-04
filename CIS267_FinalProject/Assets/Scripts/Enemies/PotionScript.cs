using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("WitchEnemy"))
        {

        }
        else if(collision.gameObject.CompareTag("Background"))
        {

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
