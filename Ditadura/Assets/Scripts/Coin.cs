using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public static int coinCounter;
  
    public CoinCounter doorCoinCounter;
  

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Right" || collision.gameObject.tag == "Left")
        {
            FindObjectOfType<AudioManager>().Play("Coin");
            coinCounter++;
            GameObject door = GameObject.Find("door").gameObject;
            door.transform.Find("Canvas").GetComponent<CoinCounter>().collected_Coins = coinCounter;
            //  doorCoinCounter.collected_Coins = coinCounter;
            CanvasManager.cm.txt_coin.text = coinCounter.ToString();
            //partícula
            Destroy(gameObject);
        }

    }


    private void OnTriggerEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Right" || collision.gameObject.tag == "Left")
        {
            coinCounter++;
           
            GameObject door = GameObject.Find("door").gameObject;
            door.transform.Find("Canvas").GetComponent<CoinCounter>().collected_Coins = coinCounter;
            //  doorCoinCounter.collected_Coins = coinCounter;
            CanvasManager.cm.txt_coin.text = coinCounter.ToString();
            //partícula
            Destroy(gameObject);
        }
    }


}
