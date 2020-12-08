using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFall : MonoBehaviour
{
    private Animator anim;
    public GameObject tree;

    // Start is called before the first frame update
    void Start()
    {
        anim = tree.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D treeCollision)
    {
        if(treeCollision.gameObject.CompareTag("Arrow"))
        {
            anim.SetBool("TimeToFall", true);
            Destroy(GameObject.FindGameObjectWithTag("Arrow"));
            Destroy(this.gameObject);
        }
        if(treeCollision.gameObject.CompareTag("WitchEnemy"))
        {
            Destroy(treeCollision);
        }
    }
}
