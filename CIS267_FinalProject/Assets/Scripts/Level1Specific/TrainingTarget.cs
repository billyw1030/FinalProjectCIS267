using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingTarget : MonoBehaviour
{
    private int targetHealth = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D trainingTarget)
    {
        if (trainingTarget.gameObject.CompareTag("Arrow"))
        {
            targetHealth -= 1;

            if (targetHealth == 0)
            {
                Destroy(this.gameObject);
            }

        }
    }
}
