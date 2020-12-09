using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainGameManagerScript : MonoBehaviour
{
    //Game Variables
    private int playerLives;
    private bool hasPlatformArrows;
    private bool hasZiplineArrows;
    private bool hasFireArrows;
    private bool cheatStatus;
    private string currentLevel;

    //Public Prefab Objects
    //public GameObject basicArrow;
    //public GameObject platformArrow;
    //public GameObject ziplineArrow;
    //public GameObject fireArrow;


    //private GameObject selectedArrow;

    //Game Options
    private int startingPlayerLives = 5;



    // Start is called before the first frame update
    void Start()
    {
        //selectedArrow = GameObject.Find("Player").GetComponent<PlayerShoot>().getSelectedArrow();

        hasPlatformArrows = false;
        hasZiplineArrows = false;
        hasFireArrows = false;
        currentLevel = "Level1";
        cheatStatus = false;

        //Temp
        playerLives = startingPlayerLives;


    }

    // Update is called once per frame
    void Update()
    {
        if (cheatStatus == true)
        {
            cheatSceneTester();
        }

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

    public void setCheatStatus(bool c)
    {
        cheatStatus = c;
    }
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

    public void playerLifeUp()
    {
        playerLives = playerLives + 1;
        Debug.Log("Player Life Up! Player now has " + playerLives + " lives remaining");
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
            Time.timeScale = 1;
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
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            Debug.Log("life Added");
            playerLives += 1;
        }
    }

    //private void mainUI()
    //{
    //    if (selectedArrow == basicArrow)
    //    {
    //        GameObject.Find("BasicArrowSelected").SetActive(true);
    //        GameObject.Find("PlatformArrowSelected").SetActive(false);
    //        GameObject.Find("ZiplineArrowSelected").SetActive(false);
    //        GameObject.Find("FireArrowSelected").SetActive(false);
    //    }
    //    else if (selectedArrow == platformArrow)
    //    {
    //        GameObject.Find("BasicArrowSelected").SetActive(false);
    //        GameObject.Find("PlatformArrowSelected").SetActive(true);
    //        GameObject.Find("ZiplineArrowSelected").SetActive(false);
    //        GameObject.Find("FireArrowSelected").SetActive(false);
    //    }
    //    else if (selectedArrow == ziplineArrow)
    //    {
    //        GameObject.Find("BasicArrowSelected").SetActive(false);
    //        GameObject.Find("PlatformArrowSelected").SetActive(false);
    //        GameObject.Find("ZiplineArrowSelected").SetActive(true);
    //        GameObject.Find("FireArrowSelected").SetActive(false);
    //    }
    //    else if (selectedArrow == fireArrow)
    //    {
    //        GameObject.Find("BasicArrowSelected").SetActive(false);
    //        GameObject.Find("PlatformArrowSelected").SetActive(false);
    //        GameObject.Find("ZiplineArrowSelected").SetActive(false);
    //        GameObject.Find("FireArrowSelected").SetActive(true);
    //    }
        
    //}
}
