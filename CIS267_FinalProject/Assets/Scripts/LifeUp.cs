using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUp : MonoBehaviour
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
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("life up");
            gameManagerScript.playerLifeUp();
            Destroy(this.gameObject);
        }
    }

    public void levelSurvived()
    {
        gameManagerScript.playerLifeUp();
    }
}
