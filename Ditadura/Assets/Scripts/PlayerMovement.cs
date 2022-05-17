using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float velocity, impulse;

    private float inpX, inpXB4Jump;
    private Rigidbody2D rb;

    public GameObject go_ground;
    private bool changeDirection;
    private bool jumped;
    public bool isGrounded;

    private groundCheck gc;

    public int life = 3;

    public  bool imortal;

    public GameObject heart3, heart2, heart1;

    private PlayerMovement pm;

    public bool IncapableToMove;

    private bool CanEnterDoor;

    public bool LeverArea,LeverCenter,LeverRight , LeverLeft;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        gc = go_ground.GetComponent<groundCheck>();
        pm = GetComponent<PlayerMovement>();
        LeverCenter = true;
        
      
    }

    void Update()
    {
        

        //RIGHT
        if (LeverArea == true && Input.GetKeyDown(KeyCode.E))
        {
            GameObject leverPivot = GameObject.Find("Lever").transform.Find("PivotBast").gameObject;

            if (LeverCenter)
            {
                leverPivot.GetComponent<Animator>().SetBool("Right", true);
                LeverRight = true;
                LeverCenter = false;
                LeverLeft = false;
            }
            else if(LeverLeft)
            {
                leverPivot.GetComponent<Animator>().SetBool("Left", false);
                leverPivot.GetComponent<Animator>().SetBool("Right", false);
                LeverRight = false;
                LeverCenter = true;
                LeverLeft = false;
            }
            
           
           
        }
        

        if(LeverArea == true && Input.GetKeyDown(KeyCode.Q))
        {
            //LEFT
            GameObject leverPivot = GameObject.Find("Lever").transform.Find("PivotBast").gameObject;

            if (LeverCenter)
            {
                leverPivot.GetComponent<Animator>().SetBool("Left", true);
                LeverRight = false;
                LeverCenter = false;
                LeverLeft = true;
            }
            else if (LeverRight)
            {
                leverPivot.GetComponent<Animator>().SetBool("Left", false);
                leverPivot.GetComponent<Animator>().SetBool("Right", false);
                LeverRight = false;
                LeverCenter = true;
                LeverLeft = false;
            }
        }


        if(transform.eulerAngles.z != 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }


        if(Input.GetKeyDown(KeyCode.E) && CanEnterDoor)
        {
            SceneManager.LoadScene(gameObject.scene.buildIndex + 1);

        }


        isGrounded = gc.isGrounded;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded)
            {
                Jump();
            }

        }

    }

    private void FixedUpdate()
    {
        if(IncapableToMove == false)
        {
            inpX = Input.GetAxis("Horizontal");
        }
        else
        {
            inpX = 0f ;
        }
      

        if (isGrounded)
        {
            
            rb.velocity = new Vector2(inpX * velocity * Time.deltaTime, rb.velocity.y);
                       
            changeDirection = false;
            jumped = false;
            inpXB4Jump = 0;

        }
        else //Se estiver no ar
        {
            velocidadeNoAr();
        }


    }

    


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "BlueButton")
        {
            collision.gameObject.GetComponent<Animator>().Play("buttonPressed");
        }


        if(collision.tag == "NetTrap")
        {
            // slow 
            StartCoroutine(NetTrapEffect());


        }

        if(collision.tag == "Lever")
        {
            LeverArea = true;
           
        }

        if (collision.tag == "Door")
        {
            CanEnterDoor = true;
        }

        if (collision.tag == "Head")
        {
           
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * impulse, ForceMode2D.Impulse);    
            Destroy(collision.gameObject.transform.parent.gameObject);
        }

        if (collision.tag == "projectile")
        {
            if (imortal == false)
            {
               
                PerderVida(1);
                Knockback(collision.gameObject.GetComponent<projectile>().right,8);
                Destroy(collision.gameObject);
            }
        }

        if(collision.tag == "Spikes_Range")
        {
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.transform.parent.gameObject.GetComponent<EnemyMov>().SpikesTrigger();
        }

        if(collision.tag == "Area")
        {
            collision.gameObject.transform.parent.GetComponent<EnemyMov>().AreaAtack();
        }

        if (collision.tag == "PushTrap_Range")
        {
            //Play trap anim
            collision.gameObject.transform.parent.GetComponent<Animator>().SetBool("Activate", true);
            // Detect push trap col with player
            // knockback

        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "BlueButton")
        {
            collision.gameObject.GetComponent<Animator>().Play("buttonRelease");
        }

        if (collision.tag == "Lever")
        {
            LeverArea = false;
           
        }

        if (collision.tag == "PushTrap_Range")
        {
            //Play trap anim
            collision.gameObject.transform.parent.GetComponent<Animator>().SetBool("Activate", false);
            // Detect push trap col with player
            // knockback

        }

        if(collision.tag == "Door")
        {
            CanEnterDoor = false;
        }
    }

    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PushTrapRight")
        {
            Knockback(true, 60);
        }

        if (collision.gameObject.tag == "PushTrapLeft")
        {
            Knockback(false, 60);
        }

        if(collision.gameObject.tag == "PushTrapUp")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 60, ForceMode2D.Impulse);
        }

        if(collision.gameObject.tag == "Spike")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 6, ForceMode2D.Impulse);
            PerderVida(3);

        }
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Spikes")
        {
            if (imortal == false)
            {
                PerderVida(1);
                
            }
        }

        if(other.tag == "Rastro" || other.tag == "Cloud")
        {
            if(imortal == false)
            {
                PerderVida(1);
                int random_num = UnityEngine.Random.Range(0, 2);
                if (random_num == 0)
                {
                    Knockback(true, 4f);
                }
                else
                {
                    Knockback(false, 4f);
                }

            }
        }

       
    }


   


    private void Jump()
    {
        rb.AddForce(Vector2.up * impulse, ForceMode2D.Impulse);
        StartCoroutine(Pulo());
        StartCoroutine(inputB4Jump());

    }

    IEnumerator Pulo()
    {
        yield return new WaitForSeconds(0.1f);
        jumped = true;

    }

    IEnumerator inputB4Jump()
    {
        yield return new WaitForSeconds(0.1f);
        inpXB4Jump = rb.velocity.x;

    }


    private void velocidadeNoAr()
    {
        #region Velocidade No Ar 
        if(!imortal)
        {
            if (rb.velocity.x > 15 && inpXB4Jump > 0 && changeDirection == false)
            {
                rb.velocity = new Vector2(inpX * velocity * Time.deltaTime, rb.velocity.y);

            }
            else if (rb.velocity.x < -15 && inpXB4Jump < 0 && changeDirection == false)
            {
                rb.velocity = new Vector2(inpX * velocity * Time.deltaTime, rb.velocity.y);

            }
            else if (rb.velocity.x > 0 && inpXB4Jump < 0)
            {
                rb.velocity = new Vector2(inpX * velocity / 2 * Time.deltaTime, rb.velocity.y);
                changeDirection = true;

            }
            else if (rb.velocity.x < 0 && inpXB4Jump > 0)
            {
                rb.velocity = new Vector2(inpX * velocity / 2 * Time.deltaTime, rb.velocity.y);
                changeDirection = true;

            }
            else if (jumped == false)
            {
                rb.velocity = new Vector2(inpX * velocity * Time.deltaTime, rb.velocity.y);

            }
            else if (inpXB4Jump == 0 && jumped == true)
            {
                rb.velocity = new Vector2(inpX * velocity / 2 * Time.deltaTime, rb.velocity.y);

            }
            else
            {
                rb.velocity = new Vector2(inpX * velocity / 2 * Time.deltaTime, rb.velocity.y);

            }

        }
        else
        {
            rb.velocity = new Vector2(inpX * velocity * Time.deltaTime, rb.velocity.y);
        }


        #endregion
    }
    
    public void PerderVida(int damage)
    {
        if(imortal == false)
        {
            life = life - damage;

            switch (life)
            {
                case 0:
                    heart1.SetActive(false);
                    heart2.SetActive(false);
                    heart3.SetActive(false);
                    break;

                case 1:
                    heart1.SetActive(true);
                    heart2.SetActive(false);
                    heart3.SetActive(false);
                    break;

                case 2:
                    heart1.SetActive(true);
                    heart2.SetActive(true);
                    heart3.SetActive(false);
                    break;

                case 3:
                    heart1.SetActive(true);
                    heart2.SetActive(true);
                    heart3.SetActive(true);
                    break;

            }
        }
        

        StartCoroutine(Invulnerability());
    }

    IEnumerator Invulnerability()
    {
        imortal = true;
        yield return new WaitForSeconds(1f);
        imortal = false;
        //Play anim
    }
    
    public void Knockback(bool right, float impact)
    {    
        Vector2 diag_left = new Vector2(-200, 0);
        Vector2 diag_right = new Vector2(200, 0);


        if (right)
        {
           // GetComponent<Rigidbody2D>().AddForce(Vector2.up * impulse, ForceMode2D.Impulse);
            GetComponent<Rigidbody2D>().AddForce(diag_right* impact , ForceMode2D.Force);
        }
        else
        {
           // GetComponent<Rigidbody2D>().AddForce(Vector2.up * impulse, ForceMode2D.Impulse);
            GetComponent<Rigidbody2D>().AddForce(diag_left * impact, ForceMode2D.Force);
        }
    }


    IEnumerator NetTrapEffect()
    {
        velocity = 400f;
        GetComponent<Animator>().SetBool("Slowed", true);
        yield return new WaitForSeconds(3f);
        GetComponent<Animator>().SetBool("Slowed", false);
        velocity = 800f;
    }
   



 }