using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHead : MonoBehaviour
{
    public GameObject coinDrop;
    public bool shooter;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void FixedUpdate()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(shooter)
            {
                int dropAmount2 = gameObject.transform.parent.GetComponent<EnemyShooter>().coinsDropAmount;
                DropCoins(dropAmount2, collision);
               
                
            }
            else
            {
                int dropAmount = gameObject.transform.parent.GetComponent<EnemyMov>().coinsDropAmount;
                DropCoins(dropAmount, collision);
               
            }
          
        }
      
        
    }

    private void DropCoins(int Amount, Collider2D collision)
    {


        for (int i = 0; i < Amount; i++)
        {
            int randomint = UnityEngine.Random.Range(0, 2);
            if(randomint == 0)
            {
                Vector3 randomVector = new Vector3(UnityEngine.Random.Range(-2, 0), UnityEngine.Random.Range(0, 3), 0);
                GameObject coinDropPrefab = Instantiate(coinDrop, collision.transform.position + randomVector, Quaternion.identity);
            }
            else
            {
                Vector3 randomVector = new Vector3(UnityEngine.Random.Range(1, 3), UnityEngine.Random.Range(0, 3), 0);
                GameObject coinDropPrefab = Instantiate(coinDrop, collision.transform.position + randomVector, Quaternion.identity);
            }
          
        }
    }

}
