using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    private float fire_rate;
    public Transform spawnPoint;
    public GameObject projectile;
    public float force;

    public bool position_shooter;
    public GameObject centro;
    public GameObject player_go;

    public int coinsDropAmount;

    void Start()
    {
       
        StartCoroutine(shoot());
        
    }


    void Update()
    {
        if(position_shooter)
        {
            RotateTowardsPlayer();
        }
    }

    IEnumerator shoot()
    { 
       
        GameObject bullet = Instantiate(projectile, spawnPoint.position, Quaternion.identity);
        Destroy(bullet, 2f);

        if (position_shooter)
        {
            bullet.GetComponent<Rigidbody2D>().AddForce(-spawnPoint.transform.right * force, ForceMode2D.Force);
        }
        else
        {
            if (transform.localScale.x == -1)
            {
                bullet.GetComponent<projectile>().right = false;
                bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force, ForceMode2D.Force);
            }
            else
            {
                bullet.GetComponent<projectile>().right = true;
                bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force, ForceMode2D.Force);
            }
        }
           
       
        yield return new WaitForSeconds(2f);

        StartCoroutine(shoot());
    }

    private void RotateTowardsPlayer()
    {
        Vector3 direction = centro.transform.position - player_go.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
