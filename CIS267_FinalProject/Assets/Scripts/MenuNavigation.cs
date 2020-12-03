using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void loadGame()
    {
        DontDestroyOnLoad(GameObject.Find("GameManager"));
        GameObject.Find("GameManager").GetComponent<MainGameManagerScript>().playerLives = 3;
        SceneManager.LoadScene("Level1");
        //Debug.Log("ButtonClicked");
    }

    public void exitGame()
    {
        //Only works on build of game
        Application.Quit();
    }

    public void settings()
    {

    }
}
