using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    MainGameManagerScript gameManagerScript;
    //private GameObject pauseObjects;
    //private GameObject pauseSettingsObject;
    //private bool isPaused;

    [SerializeField] private GameObject pauseObjects;

    [SerializeField] private GameObject pauseSettingsObject;

    [SerializeField] private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<MainGameManagerScript>();

        //Menu Stuff
        //Time.timeScale = 1;
        //pauseObjects = GameObject.FindGameObjectWithTag("ShowOnPause");
        //pauseSettingsObject = GameObject.FindGameObjectWithTag("ShowSettings");
        //hideSettings();
        //hidePauseMenu();
    }

    // Update is called once per frame
    void Update()
    {
        //Pause Menu Stuff
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
        
        if (isPaused)
        {
            //Time.timeScale = 0;
            //Debug.Log("Show Menu");
            ActivateMenu();
        }
        else
        {
            //Time.timeScale = 1;
            //Debug.Log("Hide Menu");
            DeactivateMenu();
            DeactivateSettingsMenu();
        }

        
    }

    public void ActivateMenu()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseObjects.SetActive(true);
        //isPaused = true;
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseObjects.SetActive(false);
        isPaused = false;
    }

    public void ActivateSettingsMenu()
    {
        pauseObjects.SetActive(false);
        pauseSettingsObject.SetActive(true);
    }

    public void DeactivateSettingsMenu()
    {
        pauseSettingsObject.SetActive(false);
        if (isPaused == true)
        {
            pauseObjects.SetActive(true);
        }
    }

    public void cheatsEnabled()
    {
        gameManagerScript.setCheatStatus(true);
        DeactivateSettingsMenu();
    }

    public void cheatsDisabled()
    {
        gameManagerScript.setCheatStatus(false);
        DeactivateSettingsMenu();
    }

    public void backButton()
    {
        DeactivateSettingsMenu();
    }


    //Pause Menu Funcitons
    //public void openPauseMenu()
    //{
    //    pauseObjects.SetActive(true);
    //    Time.timeScale = 0;

    //    //pauseSettingsObject.SetActive(false);
    //}
    //public void hidePauseMenu()
    //{
    //    Time.timeScale = 1;
    //    pauseObjects.SetActive(false);
    //    pauseSettingsObject.SetActive(false);
    //    isPaused = false;
    //}
    //public void showSettings()
    //{
    //    pauseObjects.SetActive(false);
    //    pauseSettingsObject.SetActive(true);
    //}
    //public void hideSettings()
    //{
    //    pauseObjects.SetActive(true);
    //    pauseSettingsObject.SetActive(false);
    //}
    //public void cheatsEnabled()
    //{
    //    gameManagerScript.setCheatStatus(true);
    //    //hidePauseMenu();
    //    //Time.timeScale = 1;
    //}
    //public void cheatsDisabled()
    //{
    //    gameManagerScript.setCheatStatus(false);
    //    //hidePauseMenu();
    //    //Time.timeScale = 1;
    //}
    //public void backButton()
    //{
    //    hideSettings();
    //}

    public void winMenuButton()
    {
        gameManagerScript.loadMainMenu();
    }

    public void loadGame()
    {
        gameManagerScript.resetPlayer();
        gameManagerScript.startCurrentLevel();
        //Debug.Log("ButtonClicked");
    }

    public void exitGame()
    {
        //Only works on build of game
        Application.Quit();
    }

}
