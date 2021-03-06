﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollectable : MonoBehaviour
{
    //Settings
    public float maxRise;
    public float maxFall;
    public float wiggleSpeed;
    public AudioClip pickup;

    //Variables
    float startingPosition;
    float currentPosition;
    bool goingUp;

    // Start is called before the first frame update
    void Start()
    {
        goingUp = true;
        startingPosition = this.gameObject.transform.position.y;
        currentPosition = startingPosition;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move()
    {
        if (goingUp)
        {
            currentPosition += wiggleSpeed * Time.deltaTime;
            this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x, currentPosition);

            if (currentPosition >= (startingPosition + maxRise))
            {
                goingUp = false;
            }
        }
        else
        {
            currentPosition -= wiggleSpeed * Time.deltaTime;
            this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x, currentPosition);

            if (currentPosition <= (startingPosition - maxRise))
            {
                goingUp = true;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == GameObject.Find("Player").transform.GetChild(1))
        {
            //Wrong player collider
            Physics2D.IgnoreCollision(this.gameObject.GetComponent<BoxCollider2D>(), collision.gameObject.GetComponent<BoxCollider2D>());
        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            
            if (this.gameObject.CompareTag("PlatformArrow"))
            {
                collision.gameObject.GetComponent<PlayerShoot>().setUnlockedPlatformArrows(true);
                GetComponent<AudioSource>().PlayOneShot(pickup);
                Destroy(this.gameObject);
            }
            else if(this.gameObject.CompareTag("ZiplineArrow"))
            {
                collision.gameObject.GetComponent<PlayerShoot>().setUnlockedZiplineArrows(true);
                GetComponent<AudioSource>().PlayOneShot(pickup);
                Destroy(this.gameObject);
            }
            else if(this.gameObject.CompareTag("FireArrow"))
            {
                collision.gameObject.GetComponent<PlayerShoot>().setUnlockedFireArrows(true);
                GetComponent<AudioSource>().PlayOneShot(pickup);
                Destroy(this.gameObject);
            }
            
        }
    }


}
