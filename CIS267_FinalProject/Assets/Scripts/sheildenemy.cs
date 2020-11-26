using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheildenemy : MonoBehaviour
{
    public GameObject box;
    public GameObject enemy;
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
        if (collision.gameObject.CompareTag("Box"))
        {
            Destroy(box);
            Destroy(enemy);
        }
    }
}
