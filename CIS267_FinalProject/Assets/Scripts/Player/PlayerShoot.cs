using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject basicArrow;
    public GameObject platformArrow;
    public GameObject ziplineArrow;
    public GameObject fireArrow;

    public float arrowVelocity;
    public float shootingDelay;
    public float animationLength;
    public float decisionDelay;
    public AudioClip ShootArrow;
    


    private Rigidbody2D playerRigidBody;

    //This is the current arrow being fired
    private GameObject currentArrow;

    //This is the current arrow type selected
    private GameObject selectedArrow;

    //Other Objects
    private Animator playerSpriteAnimator;
    private FinalPlayerMovement playerMovementScript;
    private MainGameManagerScript gameManagerScript;

    private float arrowTimer;
    private bool shooting;
    private bool arrowFired;
    private bool holding;

    private bool unlockedPlatformArrows;
    private bool unlockedZiplineArrows;
    private bool unlockedFireArrows;


    //Keycodes
    KeyCode shootKey = KeyCode.Z;

    KeyCode basicKey = KeyCode.Alpha1;
    KeyCode platformKey = KeyCode.Alpha2;
    KeyCode ziplineKey = KeyCode.Alpha3;
    KeyCode fireKey = KeyCode.Alpha4;

    KeyCode leftCycle = KeyCode.LeftShift;
    KeyCode rightCycle = KeyCode.X;


    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerMovementScript = GetComponent<FinalPlayerMovement>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<MainGameManagerScript>();
        playerSpriteAnimator = this.gameObject.transform.GetChild(0).GetComponent<Animator>();
        arrowTimer = 0;
        shooting = false;
        arrowFired = false;
        holding = false;
        selectedArrow = basicArrow;


        try
        {
            unlockedPlatformArrows = gameManagerScript.getHasPlatformArrows();
            unlockedZiplineArrows = gameManagerScript.getHasZiplineArrows();
            unlockedFireArrows = gameManagerScript.getHasFireArrows();
        }
        catch
        {
            unlockedPlatformArrows = false;
            unlockedZiplineArrows = false;
            unlockedFireArrows = false;
        }


    }

    // Update is called once per frame
    void Update()
    {
        shoot();
        swapArrow();
    }

    private void shoot()
    {
        if (Input.GetKeyDown(shootKey))
        {
            if (shooting == false)
            {
                playerSpriteAnimator.SetBool("isShooting", true);
                shooting = true;
                arrowTimer = 0;
            }

            
        }

        if (shooting == true)
        {
            //Ensures animation gets a chance to finish if arrow is held
            if (holding == false)
            {
                arrowTimer += Time.deltaTime;
            }

            //This part is to make sure the hold animation is ready to take over if the player is planning on holding the arrow before the fire logic begins
            //Is needed because the inital animation ends before the arrow fires (so the player can hold it)
            if(arrowTimer >= decisionDelay && Input.GetKey(shootKey) == true)
            {
                playerSpriteAnimator.SetBool("isHolding", true);
                playerMovementScript.setIsSlowed(true);
            }

            if(arrowTimer >= shootingDelay)
            {
                if (arrowFired == false)
                {
                    if (Input.GetKey(shootKey) == false)
                    {
                        //Shoot now!
                        currentArrow = Instantiate(selectedArrow);
                        GetComponent<AudioSource>().PlayOneShot(ShootArrow, 1);

                        if (playerMovementScript.getIsFacingRight())
                        {
                            currentArrow.transform.position = new Vector3(this.gameObject.transform.position.x + 0.5f / 5, this.gameObject.transform.position.y + 0.15f / 5);
                            currentArrow.GetComponent<Rigidbody2D>().velocity = new Vector3(arrowVelocity, 0, 0);
                        }
                        else
                        {
                            currentArrow.transform.position = new Vector3(this.gameObject.transform.position.x - 0.5f / 5, this.gameObject.transform.position.y + 0.15f / 5);
                            currentArrow.transform.localScale = new Vector3(-currentArrow.transform.localScale.x, currentArrow.transform.localScale.y, currentArrow.transform.localScale.z);
                            currentArrow.GetComponent<Rigidbody2D>().velocity = new Vector3(-arrowVelocity, 0, 0);
                        }

                        arrowFired = true;
                        holding = false;
                        playerSpriteAnimator.SetBool("isHolding", false);
                    }
                    else
                    {
                        //Finishes setting the condition to holding
                        holding = true;
                        playerSpriteAnimator.SetBool("isHolding", true);

                    }
                }
                else
                {
                    playerMovementScript.setIsSlowed(false);

                    //This section finishes the animation

                    if (arrowTimer >= animationLength)
                    { 
                        playerSpriteAnimator.SetBool("isShooting", false);
                        shooting = false;
                        arrowFired = false;
                        arrowTimer = 0;
                    }
                }
            }
        }
    }

    private void swapArrow()
    {
        if (shooting == false)
        {
            if (Input.GetKeyDown(basicKey))
            {
                selectedArrow = basicArrow;
            }
            else if (Input.GetKeyDown(platformKey) && unlockedPlatformArrows)
            {
                selectedArrow = platformArrow;
            }
            else if (Input.GetKeyDown(ziplineKey) && unlockedZiplineArrows)
            {
                selectedArrow = ziplineArrow;
            }
            else if (Input.GetKeyDown(fireKey) && unlockedFireArrows)
            {
                selectedArrow = fireArrow;
            }
            else if (Input.GetKeyDown(leftCycle))
            {
                if (selectedArrow == basicArrow)
                {
                    if (unlockedFireArrows)
                    {
                        selectedArrow = fireArrow;
                    }
                    else if (unlockedZiplineArrows)
                    {
                        selectedArrow = ziplineArrow;
                    }
                    else if (unlockedPlatformArrows)
                    {
                        selectedArrow = platformArrow;
                    }
                    //Stays the same if else
                }
                else if (selectedArrow == platformArrow)
                {
                    //Will always cycle to basic arrow
                    selectedArrow = basicArrow;
                }
                else if (selectedArrow == ziplineArrow)
                {
                    //Really don't need these but you never know
                    if (unlockedPlatformArrows)
                    {
                        selectedArrow = platformArrow;
                    }
                    else
                    {
                        selectedArrow = basicArrow;
                    }
                }
                else if (selectedArrow == fireArrow)
                {
                    if (unlockedZiplineArrows)
                    {
                        selectedArrow = ziplineArrow;
                    }
                    else if (unlockedPlatformArrows)
                    {
                        selectedArrow = platformArrow;
                    }
                    else
                    {
                        selectedArrow = basicArrow;
                    }
                }
            }
            else if (Input.GetKeyDown(rightCycle))
            {
                if (selectedArrow == basicArrow)
                {

                    if (unlockedPlatformArrows)
                    {
                        selectedArrow = platformArrow;
                    }
                    else if (unlockedZiplineArrows)
                    {
                        selectedArrow = ziplineArrow;
                    }
                    else if (unlockedFireArrows)
                    {
                        selectedArrow = fireArrow;
                    }

                }
                else if (selectedArrow == platformArrow)
                {
                    if (unlockedZiplineArrows)
                    {
                        selectedArrow = ziplineArrow;
                    }
                    else if (unlockedFireArrows)
                    {
                        selectedArrow = fireArrow;
                    }
                    else
                    {
                        selectedArrow = basicArrow;
                    }
                }
                else if (selectedArrow == ziplineArrow)
                {
                    if (unlockedFireArrows)
                    {
                        selectedArrow = fireArrow;
                    }
                    else
                    {
                        selectedArrow = basicArrow;
                    }
                }
                else if (selectedArrow == fireArrow)
                {
                    //Will always cycle to basic arrow
                    selectedArrow = basicArrow;
                }
            }



            //Animation Variables
            if (selectedArrow == basicArrow)
            {
                playerSpriteAnimator.SetBool("hasPlatform", false);
                playerSpriteAnimator.SetBool("hasZipline", false);
                playerSpriteAnimator.SetBool("hasFire", false);
            }
            else if (selectedArrow == platformArrow)
            {
                playerSpriteAnimator.SetBool("hasPlatform", true);
                playerSpriteAnimator.SetBool("hasZipline", false);
                playerSpriteAnimator.SetBool("hasFire", false);
            }
            else if (selectedArrow == ziplineArrow)
            {
                //Currently Not Set Up!
                playerSpriteAnimator.SetBool("hasPlatform", false);
                playerSpriteAnimator.SetBool("hasZipline", false);
                playerSpriteAnimator.SetBool("hasFire", false);
            }
            else if (selectedArrow == fireArrow)
            {
                playerSpriteAnimator.SetBool("hasPlatform", false);
                playerSpriteAnimator.SetBool("hasZipline", false);
                playerSpriteAnimator.SetBool("hasFire", true);
            }


        }
        
    }



    //Getters and Setters

    public void setUnlockedPlatformArrows(bool p)
    {
        unlockedPlatformArrows = p;
        gameManagerScript.setHasPlatformArrows(true);
    }
    public void setUnlockedZiplineArrows(bool z)
    {
        unlockedZiplineArrows = z;
        gameManagerScript.setHasZiplineArrows(true);
    }
    public void setUnlockedFireArrows(bool f)
    {
        unlockedFireArrows = f;
        gameManagerScript.setHasFireArrows(true);
    }

    public GameObject getSelectedArrow()
    {
        return selectedArrow;
    }


}
