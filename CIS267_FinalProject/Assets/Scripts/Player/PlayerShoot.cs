using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject basicArrow;
    public float arrowVelocity;
    public float shootingDelay;


    private Rigidbody2D playerRigidBody;
    private GameObject currentArrow;
    private Animator playerSpriteAnimator;
    private PlayerMovement playerMovementScript;

    private float arrowTimer;
    bool shooting;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerMovementScript = GetComponent<PlayerMovement>();
        playerSpriteAnimator = this.gameObject.transform.GetChild(0).GetComponent<Animator>();
        arrowTimer = 0;
        shooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    private void shoot()
    {
        if (Input.GetKeyDown(KeyCode.Z))
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
            arrowTimer += Time.deltaTime;

            if(arrowTimer >= shootingDelay)
            {
                currentArrow = Instantiate(basicArrow);
               
                if (playerMovementScript.getIsFacingRight())
                {
                    currentArrow.transform.position = new Vector3(this.gameObject.transform.position.x + 0.5f, this.gameObject.transform.position.y + 0.15f);
                    currentArrow.GetComponent<Rigidbody2D>().velocity = new Vector3(arrowVelocity, 0, 0);
                }
                else
                {
                    currentArrow.transform.position = new Vector3(this.gameObject.transform.position.x - 0.5f, this.gameObject.transform.position.y + 0.15f);
                    currentArrow.transform.localScale = new Vector3(-currentArrow.transform.localScale.x, currentArrow.transform.localScale.y, currentArrow.transform.localScale.z);
                    currentArrow.GetComponent<Rigidbody2D>().velocity = new Vector3(-arrowVelocity, 0, 0);
                }

                playerSpriteAnimator.SetBool("isShooting", false);
                shooting = false;
                arrowTimer = 0;
            }
        }
    }

    private void fireArrow()
    {

    }
}
