using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Transition : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D levelOneTransition)
    {
        if (levelOneTransition.gameObject.CompareTag("Player") && player.gameObject.GetComponent("keyObtained") == true)
        {
            Debug.Log("Door Open");
        }
        else if(levelOneTransition.gameObject.CompareTag("Player") && player.gameObject.GetComponent("keyObtained") == false)
        {
            Debug.Log("No Key");
        }
    }
}
