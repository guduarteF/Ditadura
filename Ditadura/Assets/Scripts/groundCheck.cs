using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    public static groundCheck g;
    public bool isGrounded;
   
    void Start()
    {
        g = this;
    }

   
    void Update()
    {
       
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
         
            isGrounded = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            
            isGrounded = false;
        }
    }
}
