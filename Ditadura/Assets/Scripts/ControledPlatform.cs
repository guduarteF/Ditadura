using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControledPlatform : MonoBehaviour
{
    public float speed;
    public int startingPoint;
    public Transform[] points;
    private bool center, right, left;

    private int i; // index

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startingPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        center = GameObject.Find("Player").GetComponent<PlayerMovement>().LeverCenter;
        right = GameObject.Find("Player").GetComponent<PlayerMovement>().LeverRight;
        left = GameObject.Find("Player").GetComponent<PlayerMovement>().LeverLeft;

        //if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        //{
        //    i++;

        //    if (i == points.Length)
        //    {
        //        i = 0;
        //    }
        //}

        if(center == false)
        {
            if(right)
            {
                transform.position = Vector2.MoveTowards(transform.position, points[0].position, speed * Time.deltaTime);
            }
            else if(left)
            {
                transform.position = Vector2.MoveTowards(transform.position, points[1].position, speed * Time.deltaTime);
            }
            
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);

    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
