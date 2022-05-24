using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeft : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            transform.parent.gameObject.GetComponent<PlayerMovement>().PerderVida(1);
            transform.parent.gameObject.GetComponent<PlayerMovement>().Knockback(true, 60);
        }
    }
}
