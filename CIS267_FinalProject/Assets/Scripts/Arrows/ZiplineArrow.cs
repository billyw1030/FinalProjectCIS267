using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZiplineArrow : MonoBehaviour
{
    public GameObject chain;
    public GameObject arrow;
    private GameObject Player;
    



    // Start is called before the first frame update
    void Start()
    {
      



    }

    // Update is called once per frame
    void Update()
    {
        
        

    }
    private void OnCollisionEnter2D(Collision2D ziplineCollision)
    {
        Player = GameObject.Find("Player");
        
        if (ziplineCollision.gameObject.CompareTag("endline"))
        {
            Debug.Log("Grapple");
            Player.transform.position = arrow.gameObject.transform.position;
            Debug.Log("Player moved");
            Destroy(this.gameObject);



        }
        else if (!ziplineCollision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }




}
