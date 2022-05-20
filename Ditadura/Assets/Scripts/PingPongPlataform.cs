using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongPlataform : MonoBehaviour
{
    public static PingPongPlataform ppp;
 
    public float speed;
    public int startingPoint;
    public Transform[] points;
    public bool bluebutton;
    public bool readyToGo;
    public GameObject buttonB;
    private bool hitTheEnd;
    public int time;


    private int i; // index

    // Start is called before the first frame update
    void Start()
    {
        ppp = this;
        transform.position = points[0].position;
        i = 0;
        readyToGo = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (bluebutton && readyToGo)
        {
            i = 1;
            bluebutton = false;
            readyToGo = false;
            StartCoroutine(TimeToRelease());
        }



            if (Vector2.Distance(transform.position, points[1].position) < 0.02f)
            {
                i = 0;
               

            }
                     

            
            transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);

    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }

    IEnumerator TimeToRelease()
    {
        yield return new WaitForSeconds(time);
        buttonB.GetComponent<Animator>().Play("buttonRelease");
        readyToGo = true;

    }
}
