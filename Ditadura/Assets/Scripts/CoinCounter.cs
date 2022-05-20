using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CoinCounter : MonoBehaviour
{
    public static CoinCounter cc;

    public Text txt_coin_Counter;
    public  int collected_Coins;
    public  int minimumAmount;
    public GameObject door , E_Key;
   

    void Start()
    {
        cc = this;
    }

    // Update is called once per frame
    void Update()
    {
        txt_coin_Counter.text = collected_Coins + " / " + minimumAmount;

        if(collected_Coins >= minimumAmount)
        {
            // door anim
            door.GetComponent<Animator>().SetBool("OpenDoor", true);
            E_Key.SetActive(true);
            // enter door
            // next lv
        }
    }
}
