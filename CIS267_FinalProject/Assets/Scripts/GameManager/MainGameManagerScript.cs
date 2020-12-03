using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameManagerScript : MonoBehaviour
{
    public int playerLives;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerLives == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
