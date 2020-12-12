using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{
    //Objects
    MainGameManagerScript gameManagerScript;
    LifeUp lifeScript;

    public AudioClip PlayerDeath;
    public AudioClip PotionBreak;
    public AudioClip Swing1;
    public AudioClip extraheart;

    private bool keyObtained = false;
    private bool drop;
    private float hit = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<MainGameManagerScript>();
        lifeScript = GameObject.Find("GameManager").GetComponent<LifeUp>();
        drop = false;
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
            lifeScript.levelSurvived();
            gameManagerScript.setCurrentLevel("Level2");
            gameManagerScript.startCurrentLevel();
        }
        else if (other.gameObject.CompareTag("loadnext"))
        {
            lifeScript.levelSurvived();
            gameManagerScript.setCurrentLevel("Level3");
            gameManagerScript.startCurrentLevel();


        }
        else if (other.gameObject.CompareTag("river"))
        {
            gameManagerScript.playerDeath();
            if (hit == 0)
            {
                
                GetComponent<AudioSource>().PlayOneShot(PlayerDeath);
                hit++;
            }
            
            
        }
        else if (other.gameObject.CompareTag("Potion"))
        {
           
            gameManagerScript.playerDeath();
            if (hit == 0)
            {
                GetComponent<AudioSource>().PlayOneShot(PotionBreak);
                GetComponent<AudioSource>().PlayOneShot(PlayerDeath, 3);
                hit++;
            }
            
        }




        //if (other.gameObject.CompareTag("OutOfBounds"))
        //{
        //    //Debug.Log("Out");
        //    SceneManager.LoadScene("SampleScene");
        //}
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (drop)
        {


            if (collision.gameObject.CompareTag("Ground") == false && collision.gameObject.CompareTag("PlatformArrow") == false && collision.gameObject.CompareTag("Box") == false)
            {
                try
                {
                    Physics2D.IgnoreCollision(this.gameObject.GetComponent<BoxCollider2D>(), collision.gameObject.GetComponent<Collider2D>());
                }
                catch
                {
                    Debug.Log("Collider Error");
                }
            }
            else
            {
                this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                drop = false;
            }
        }
        else
        { //physics2d.ignore
            if(gameManagerScript.getIsVulnerable() == false)
            {
                if(collision.gameObject.CompareTag("HammerEnemy"))
                {
                    Physics2D.IgnoreCollision(this.gameObject.GetComponent<BoxCollider2D>(), collision.gameObject.GetComponent<BoxCollider2D>());
                }
                else if(collision.gameObject.CompareTag("WitchEnemy"))
                {
                    Physics2D.IgnoreCollision(this.gameObject.GetComponent<BoxCollider2D>(), collision.gameObject.GetComponent<BoxCollider2D>());
                }
                else if (collision.gameObject.CompareTag("Life"))
                {
                    gameManagerScript.playerLifeUp();

                    Destroy(collision.gameObject);
                    GetComponent<AudioSource>().PlayOneShot(extraheart);
                }

            }
            else if (collision.gameObject.CompareTag("HammerEnemy") && gameManagerScript.getIsVulnerable() == true)
            {
                
                gameManagerScript.playerDeath();
                if (hit == 0)
                {
                    GetComponent<AudioSource>().PlayOneShot(Swing1);
                    GetComponent<AudioSource>().PlayOneShot(PlayerDeath, 3);
                    hit++;
                }


                /*

                Debug.Log("HammerCollision");
                GameObject.Find("GameManager").GetComponent<MainGameManagerScript>().playerLives = GameObject.Find("GameManager").GetComponent<MainGameManagerScript>().playerLives - 1;
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
                */
            }
            else if (collision.gameObject.CompareTag("WitchEnemy") && gameManagerScript.getIsVulnerable() == true)
            {
                //GetComponent<AudioSource>().PlayOneShot(PlayerDeath);
                gameManagerScript.playerDeath();
                if (hit == 0)
                {
                    GetComponent<AudioSource>().PlayOneShot(PlayerDeath);
                    hit++;
                }
                


            }
            else if (collision.gameObject.CompareTag("Life"))
            {
                gameManagerScript.playerLifeUp();
              
                Destroy(collision.gameObject);
                GetComponent<AudioSource>().PlayOneShot(extraheart);
            }

        }

    }

    //Getters and Setters
    public void setDrop(bool d)
    {
        this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        drop = d;
    }
}
