using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{
    private bool keyObtained = false;

    // Start is called before the first frame update
    void Start()
    {

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
            Destroy(GameObject.Find("Key"));
        }
        else if (other.gameObject.CompareTag("Door") && keyObtained == true)
        {
            DontDestroyOnLoad(GameObject.Find("GameManager"));
            SceneManager.LoadScene("Level2");
        }
        else if (other.gameObject.CompareTag("loadnext"))
        {
            SceneManager.LoadScene("Level3");
            DontDestroyOnLoad(GameObject.Find("GameManager"));


        }
        else if (other.gameObject.CompareTag("river"))
        {

            SceneManager.LoadScene("Level2");
        }
        else if (other.gameObject.CompareTag("Potion") || other.gameObject.CompareTag("WitchEnemy"))
        {
            Debug.Log("Player has been hit!");
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
            Debug.Log("HammerCollision");
            GameObject.Find("GameManager").GetComponent<MainGameManagerScript>().playerLives = GameObject.Find("GameManager").GetComponent<MainGameManagerScript>().playerLives - 1;
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
