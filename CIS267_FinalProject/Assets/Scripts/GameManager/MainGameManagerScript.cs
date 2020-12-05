using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameManagerScript : MonoBehaviour
{
    //Game Variables
    private int playerLives;
    private bool hasPlatformArrows;
    private bool hasZiplineArrows;
    private bool hasFireArrows;
    private string currentLevel;

    //Game Options
    private int startingPlayerLives = 10;



    // Start is called before the first frame update
    void Start()
    {
        hasPlatformArrows = false;
        hasZiplineArrows = false;
        hasFireArrows = false;
        currentLevel = "Level1";

        //Temp
        playerLives = startingPlayerLives;
    }

    // Update is called once per frame
    void Update()
    {
        cheatSceneTester();
    }


    //Getters

    public int getPlayerLives()
    {
        return playerLives;
    }
    public bool getHasPlatformArrows()
    {
        return hasPlatformArrows;
    }
    public bool getHasZiplineArrows()
    {
        return hasZiplineArrows;
    }
    public bool getHasFireArrows()
    {
        return hasFireArrows;
    }

    //Setters

    public void setPlayerLives(int l)
    {
        playerLives = l;
    }
    public void addPlayerLives(int al)
    {
        playerLives += al;
    }
    public void setHasPlatformArrows(bool p)
    {
        hasPlatformArrows = p;
    }
    public void setHasZiplineArrows(bool z)
    {
        hasZiplineArrows = z;
    }
    public void setHasFireArrows(bool f)
    {
        hasFireArrows = f;
    }




    //Scene Functions
    public void setCurrentLevel(string l)
    {
        currentLevel = l;
    }
    public void startCurrentLevel()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene(currentLevel);
    }

    //Gamefunctions
    public void playerDeath()
    {
        playerLives = playerLives - 1;
        Debug.Log("Player Death. Player now has " + playerLives + " lives remaining");
        if(playerLives > 0)
        {
            if(currentLevel == "Level1")
            {
                hasPlatformArrows = false;
                hasZiplineArrows = false;
                hasFireArrows = false;
            }
            else if (currentLevel == "Level2")
            {
                hasPlatformArrows = true;
                hasZiplineArrows = false;
                hasFireArrows = false;
            }
            else if (currentLevel == "Level3")
            {
                hasPlatformArrows = true;
                hasZiplineArrows = true;
                hasFireArrows = false;
            }
            startCurrentLevel();
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }


    }

    public void resetPlayer()
    {
        hasPlatformArrows = false;
        hasZiplineArrows = false;
        hasFireArrows = false;
        currentLevel = "Level1";
        playerLives = startingPlayerLives;
    }


    //Test Function
    public void testGameManager()
    {
        Debug.Log("Game Manager has been located");
    }

    private void cheatSceneTester()
    {
        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            currentLevel = "Level1";
            hasPlatformArrows = false;
            hasZiplineArrows = false;
            hasFireArrows = false;
            startCurrentLevel();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            currentLevel = "Level2";
            hasPlatformArrows = true;
            hasZiplineArrows = false;
            hasFireArrows = false;
            startCurrentLevel();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            currentLevel = "Level3";
            hasPlatformArrows = true;
            hasZiplineArrows = true;
            hasFireArrows = false;
            startCurrentLevel();
        }
    }
}
