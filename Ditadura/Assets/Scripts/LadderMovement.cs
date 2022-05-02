using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private float vertical;   // input vertical
    private float speed = 8f;
    public bool isLadder;   //Se estiver colidindo com a escada
    private bool isClimbing; // Se estiver subindo ou descendo a escada
   

    [SerializeField]
    private Rigidbody2D rb;


    private void Update()
    {     
        vertical = Input.GetAxis("Vertical");

        if(isLadder && Mathf.Abs(vertical) > 0f && !GetComponent<GroundPound>().isGroundPounding)
        {
            isClimbing = true;
        }

    }

    private void FixedUpdate()
    {
        if(isClimbing)
        {
            rb.gravityScale = 0f;   //zera a gravidade
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);  // aumenta a velocidade
        }
        else
        {
            rb.gravityScale = 2f;      

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;

        }
    }

    
}
