using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour
{
    public static EnemyMov em;

    public float speed;
    private int direction;
    private Rigidbody2D rb;
    public GameObject rayOrigin;
    public float raySize;
    public bool right;

    public bool jumper , spike , trail;
    public float jump_high;
    public ParticleSystem p_spikes;
    public ParticleSystem rastro;
    public ParticleSystem areaAttack;

    private bool spikes_delay;
    private bool readyToAttack;

    private void Start()
    {
        readyToAttack = true;
         direction = 1;
        rb = GetComponent<Rigidbody2D>();
        em = this;

        if(jumper)
        {
            StartCoroutine(Jump());
        }      

        if(trail)
        {
            StartCoroutine(TrailSpawn());
        }
        
    }
    void Update()
    {
        changeDirection();
        
        
        
    }

    private void FixedUpdate()
    {
         rb.velocity = new Vector2(direction * speed * Time.deltaTime, rb.velocity.y);
       
    }

    private void changeDirection()
    {
        Vector2 direcao_atual = new Vector2(direction, transform.position.y);       

       
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        {
            TurnAround();
           
        }

      
    }

  

    public void DamagePlayerEffects(GameObject go_collision)
    {          
        go_collision.transform.parent.GetComponent<PlayerMovement>().Knockback(right,8);
        go_collision.transform.parent.GetComponent<PlayerMovement>().PerderVida();      
    }

    IEnumerator Jump()
    {
        rb.AddForce(Vector2.up * jump_high, ForceMode2D.Impulse);

        yield return new WaitForSeconds(3f);

        StartCoroutine(Jump());
    }

    private void TurnAround()
    {
        transform.localScale = new Vector3(direction * -1, 1, 1);
        direction = direction * -1;
    }

    IEnumerator spikes()
    {
             
        if(!spikes_delay)
        {
            yield return new WaitForSeconds(0.1f);
            Instantiate(p_spikes, gameObject.transform.position, Quaternion.identity);
            spikes_delay = true;
            yield return new WaitForSeconds(2f);
            spikes_delay = false;
            GameObject spikes = transform.Find("spikes").gameObject;
            spikes.GetComponent<BoxCollider2D>().enabled = true;
        }
       
    }

    public void SpikesTrigger()
    {
        // é uma função chamando uma Coroutine pois não da pra chamar coroutine entre scripts
        // chamada pelo PlayerMovement OnTriggerEnter2D

        if(spike)
        {
            StartCoroutine(spikes());
        }
    }


    IEnumerator TrailSpawn()
    {
        Instantiate(rastro, gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(TrailSpawn());
    }

    public void AreaAtack()
    {
        if (readyToAttack == true)
        {
            Instantiate(areaAttack, gameObject.transform.position, Quaternion.identity);
            StartCoroutine(AreaAttackDelay());
        }
      
    }

    IEnumerator AreaAttackDelay()
    {

        readyToAttack = false;
        yield return new WaitForSeconds(3f);
        readyToAttack = true;

    }

}
