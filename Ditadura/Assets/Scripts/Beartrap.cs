using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beartrap : MonoBehaviour
{
    private PlayerMovement pm;
    // Start is called before the first frame update
    void Start()
    {
        pm = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            GameObject col_gameobject = collision.gameObject.transform.parent.gameObject;
            PlayerMovement PlayerScript = col_gameobject.GetComponent<PlayerMovement>();         
                      

            ActivateTrap();
            PlayerScript.PerderVida();
            //PlayerScript.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 8, ForceMode2D.Impulse);
            //PlayerScript.IncapableToMove(1.5f);
            StartCoroutine(IncapableToMoveTimer(col_gameobject));

            
        }
    }



    private void ActivateTrap()
    {
        GetComponent<Animator>().SetBool("TrapON", true);

    }

    IEnumerator IncapableToMoveTimer(GameObject Player)
    {
        Player.transform.position = new Vector3(gameObject.transform.position.x, Player.transform.position.y, Player.transform.position.z);
        Player.GetComponent<PlayerMovement>().IncapableToMove = true;
        yield return new WaitForSeconds(2f);
        Player.GetComponent<PlayerMovement>().IncapableToMove = false;
        //Destroy(gameObject);

    }


}
