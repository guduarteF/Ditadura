using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public static int coinCounter;
    private bool collided;
  

    void Start()
    {
        collided = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collided == false)
        {
            collided = true;
            
            coinCounter++;
            CanvasManager.cm.txt_coin.text = coinCounter.ToString();
            //partícula
            Destroy(gameObject);
        }

    }

  
}
