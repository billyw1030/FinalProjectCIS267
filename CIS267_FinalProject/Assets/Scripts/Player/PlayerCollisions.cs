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
        if (other.gameObject.CompareTag("Door") && keyObtained == true)
        {
            DontDestroyOnLoad(GameObject.Find("GameManager"));
            SceneManager.LoadScene("Level2");
        }
        if (other.gameObject.CompareTag("loadnext"))
        {
            SceneManager.LoadScene("Level3");
            DontDestroyOnLoad(GameObject.Find("GameManager"));
            

        }
        if (other.gameObject.CompareTag("river"))
        {
            
            SceneManager.LoadScene("Level2");
        }
        //if (other.gameObject.CompareTag("OutOfBounds"))
        //{
        //    //Debug.Log("Out");
        //    SceneManager.LoadScene("SampleScene");
        //}
    }
}
