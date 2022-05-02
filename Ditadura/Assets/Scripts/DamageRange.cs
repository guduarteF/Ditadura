using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageRange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject parent = gameObject.transform.parent.gameObject;

        if (collision.gameObject.tag == "Left")
        {
            parent.GetComponent<EnemyMov>().right = true;
            parent.GetComponent<EnemyMov>().DamagePlayerEffects(collision.gameObject);
        }

        if (collision.gameObject.tag == "Right")
        {
            parent.GetComponent<EnemyMov>().right = false;
            parent.GetComponent<EnemyMov>().DamagePlayerEffects(collision.gameObject);
        }
    }
}
