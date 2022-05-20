using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    public bool doorisopen; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenButtonDoor()
    {
        if (!doorisopen)
        {
            GetComponent<Animator>().Play("ButtonDoorOpen");
          
         
        }
        else
        {
            GetComponent<Animator>().Play("ButtonDoorClose");
           

        }
    }

    public void ReleaseButtonDoor()
    {
        if(!doorisopen)
        {
            doorisopen = true;
        }
        else
        {
            doorisopen = false;
        }

    }
}
