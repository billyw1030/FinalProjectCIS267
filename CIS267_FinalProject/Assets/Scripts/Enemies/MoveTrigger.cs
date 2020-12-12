using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrigger : MonoBehaviour
{
    private bool isActive;
    private King_IdleWatch managingScript;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setManagingScript(King_IdleWatch s)
    {
        managingScript = s;
        isActive = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isActive)
        {
            if (collision.gameObject.CompareTag("Arrow") || collision.gameObject.CompareTag("PlatformArrow") || collision.gameObject.CompareTag("ZiplineArrow") || collision.gameObject.CompareTag("FireArrow") || collision.gameObject.CompareTag("Player"))
            {
                managingScript.activateTrigger();
                isActive = false;
            }
        }
    }
}
