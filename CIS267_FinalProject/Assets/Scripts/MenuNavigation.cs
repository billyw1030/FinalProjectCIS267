using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    MainGameManagerScript gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<MainGameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            openPauseMenu();
        }
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

    public void openPauseMenu()
    {
        Time.timeScale = 0;
    }

}
