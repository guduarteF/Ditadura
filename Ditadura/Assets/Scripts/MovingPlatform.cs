using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public static MovingPlatform mp;
    public float speed;       
    public int startingPoint;
    public Transform[] points;
    private bool redbutton;
    

    private int i; // index

    // Start is called before the first frame update
    void Start()
    {
        mp = this;
        transform.position = points[startingPoint].position;  
    }

    // Update is called once per frame
    void Update()
    {
        if(!redbutton)
        {
            if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
            {
                i++;

                if (i == points.Length)
                {
                    i = 0;
                }
            }

            transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
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

    public void RedButtonPressed()
    {
        redbutton = !redbutton;
    }

   

    
}
