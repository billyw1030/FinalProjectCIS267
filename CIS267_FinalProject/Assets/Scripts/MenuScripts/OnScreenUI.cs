﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OnScreenUI : MonoBehaviour
{
    MainGameManagerScript gameManagerScript;
    PlayerShoot playerShootScript;

    //public Text livesText;
    private int lifeChecker;
    private GameObject selectedArrow;


    private GameObject heartOne;
    private GameObject heartTwo;
    private GameObject heartThree;
    private GameObject heartFour;
    private GameObject heartFive;

    private GameObject baseArrow;
    private GameObject platArrow;
    private GameObject zipArrow;
    private GameObject flameArrow;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<MainGameManagerScript>();
        playerShootScript = GameObject.Find("Player").GetComponent<PlayerShoot>();

        heartOne = GameObject.Find("Heart 1");
        heartTwo = GameObject.Find("Heart 2");
        heartThree = GameObject.Find("Heart 3");
        heartFour = GameObject.Find("Heart 4");
        heartFive = GameObject.Find("Heart 5");

        baseArrow = GameObject.Find("BaseArrow");
        platArrow = GameObject.Find("PlatArrow");
        zipArrow = GameObject.Find("ZipArrow");
        flameArrow = GameObject.Find("FlameArrow");
    }

    // Update is called once per frame
    void Update()
    {
        selectedArrow = playerShootScript.getSelectedArrow();
        lifeChecker = gameManagerScript.getPlayerLives();
        arrowDisplayer(selectedArrow);
        lifeDisplayer(lifeChecker);
       // livesText.text + = gameManagerScript.getPlayerLives().ToString();
    }

    private void arrowDisplayer(GameObject selectedArrow)
    {
        if(selectedArrow == playerShootScript.basicArrow)
        {
            baseArrow.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            platArrow.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            zipArrow.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            flameArrow.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        }
        else if (selectedArrow == playerShootScript.platformArrow)
        {
            baseArrow.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            platArrow.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            zipArrow.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            flameArrow.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        }
        else if (selectedArrow == playerShootScript.ziplineArrow)
        {
            baseArrow.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            platArrow.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            zipArrow.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            flameArrow.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        }
        else if (selectedArrow == playerShootScript.fireArrow)
        {
            baseArrow.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            platArrow.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            zipArrow.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            flameArrow.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
    }

    private void lifeDisplayer(int lives)
    {
        if(lives == 5)
        {
            heartOne.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            heartTwo.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            heartThree.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            heartFour.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            heartFive.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
        else if (lives == 4)
        {
            heartOne.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            heartTwo.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            heartThree.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            heartFour.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            heartFive.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        }
        else if (lives == 3)
        {
            heartOne.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            heartTwo.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            heartThree.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            heartFour.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            heartFive.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        }
        else if (lives == 2)
        {
            heartOne.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            heartTwo.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            heartThree.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            heartFour.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            heartFive.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);

        }
        else if (lives == 1)
        {
            heartOne.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            heartTwo.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            heartThree.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            heartFour.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            heartFive.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        }
        else if (lives == 0)
        {
            heartOne.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            heartTwo.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            heartThree.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            heartFour.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            heartFive.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        }
    }
}

