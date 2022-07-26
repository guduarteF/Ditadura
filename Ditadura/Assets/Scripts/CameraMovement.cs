using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject playerPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerPos.GetComponent<PlayerMovement>().IamDead == false)
        transform.position = new Vector3(playerPos.transform.position.x, playerPos.transform.position.y, transform.position.z);
        
    }
}
