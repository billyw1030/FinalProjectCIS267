using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchBehavior : MonoBehaviour
{
    //Public Options
    public bool enabledAtStart;
    public GameObject myPlatform;

    //private variables
    private bool isLit;

    //Components
    private Animator torchAnimator;

    // Start is called before the first frame update
    void Start()
    {
        torchAnimator = this.gameObject.GetComponent<Animator>();
        if(enabledAtStart)
        {
            myPlatform.SetActive(true);
            isLit = true;
            torchAnimator.SetBool("isOn", true);
        }
        else
        {
            myPlatform.SetActive(false);
            isLit = false;
            torchAnimator.SetBool("isOn", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("FireArrow"))
        {
            if (!isLit)
            {
                myPlatform.SetActive(true);
                isLit = true;
                torchAnimator.SetBool("isOn", true);
            }
        }
        else if (collision.gameObject.CompareTag("Arrow"))
        {
            if(isLit)
            {
                myPlatform.SetActive(false);
                isLit = false;
                torchAnimator.SetBool("isOn", false);
            }
        }
    }

    //Not useful as the moment
    /*
    private void toggleLit()
    {
        if(isLit)
        {
            myPlatform.SetActive(false);
            isLit = false;
            torchAnimator.SetBool("isOn", false);
        }
        else
        {
            myPlatform.SetActive(true);
            isLit = true;
            torchAnimator.SetBool("isOn", true);
        }
    }
    */

}
