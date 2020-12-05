using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{
    //Objects
    MainGameManagerScript gameManagerScript;

    private bool keyObtained = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<MainGameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            keyObtained = true;
            Debug.Log("Key Obtained");
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Door") && keyObtained == true)
        {
            gameManagerScript.setCurrentLevel("Level2");
            gameManagerScript.startCurrentLevel();
        }
        else if (other.gameObject.CompareTag("loadnext"))
        {
            gameManagerScript.setCurrentLevel("Level3");
            gameManagerScript.startCurrentLevel();


        }
        else if (other.gameObject.CompareTag("river"))
        {

            gameManagerScript.playerDeath();
        }
        else if (other.gameObject.CompareTag("Potion"))
        {
            gameManagerScript.playerDeath();
        }




        //if (other.gameObject.CompareTag("OutOfBounds"))
        //{
        //    //Debug.Log("Out");
        //    SceneManager.LoadScene("SampleScene");
        //}
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HammerEnemy"))
        {
            gameManagerScript.playerDeath();

            /*

            Debug.Log("HammerCollision");
            GameObject.Find("GameManager").GetComponent<MainGameManagerScript>().playerLives = GameObject.Find("GameManager").GetComponent<MainGameManagerScript>().playerLives - 1;
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            */
        }
        else if (collision.gameObject.CompareTag("WitchEnemy"))
        {
            gameManagerScript.playerDeath();
        }
    }
}
