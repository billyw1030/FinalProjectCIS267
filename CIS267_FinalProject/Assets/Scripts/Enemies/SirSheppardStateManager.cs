using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirSheppardStateManager : MonoBehaviour
{
    public GameObject startTrigger;
    public GameObject room1Trigger;

    public Vector2 room1Enter;
    public Vector2 room1Exit;

    private bool isAlive;
    private bool isFacingRight;
    private bool isFighting;
    private bool forceRight;

    private int phasecounter;
    private GameObject currentTrigger;
    private Vector2 currentCoords;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        phasecounter = 0;

        //Careful
        isFacingRight = false;
        isFighting = false;

        setPhaseDetails();
    }

    // Update is called once per frame
    void Update()
    {
        facePlayer();
    }

    public GameObject getTrigger()
    {
        return currentTrigger;
    }

    public Vector2 getNewPos()
    {
        Vector2 storeCords = currentCoords;
        setPhaseDetails();
        return storeCords;
    }

    private void setPhaseDetails()
    {
        if(phasecounter == 0)
        {
            currentTrigger = startTrigger;
            currentCoords = room1Enter;
        }
        else if (phasecounter == 1)
        {
            currentTrigger = room1Trigger;
            currentCoords = room1Exit;
        }

        phasecounter++;
    }

    private void facePlayer()
    {
        if(forceRight == true)
        {
            if (isFacingRight == false)
            {
                //Turn Right 
                transform.eulerAngles = new Vector3(0, 0, 0);
                isFacingRight = true;
            }
        }
        else if(isAlive && isFighting)
        {

           if (GameObject.Find("Player").transform.position.x > this.gameObject.transform.position.x && isFacingRight == false)
           {
              //Turn Right 
              transform.eulerAngles = new Vector3(0, 0, 0);
              isFacingRight = true;
           }
           else if (GameObject.Find("Player").transform.position.x < this.gameObject.transform.position.x && isFacingRight == true)
           {
               //Turn Left 
               transform.eulerAngles = new Vector3(0, 180, 0);
               isFacingRight = false;
           }

        }
    }

    public void setIsFighting(bool i)
    {
        isFighting = i;
    }

    public void setForceRight(bool f)
    {
        forceRight = f;
    }    
}
