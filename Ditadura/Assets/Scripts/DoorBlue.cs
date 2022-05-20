using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBlue : MonoBehaviour
{
    public static DoorBlue db;
    public bool doorReady;
    public GameObject blueButton;
    // Start is called before the first frame update
    void Start()
    {
        db = this;
        doorReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenAndCloseDoor()
    {
       
        GetComponent<Animator>().Play("DoorButtonBlueOpenClosing");
        doorReady = false;
        StartCoroutine(ReadyToOpen());
    }

    IEnumerator ReadyToOpen()
    {
        yield return new WaitForSeconds(10f);
        doorReady = true;
        blueButton.GetComponent<Animator>().Play("buttonRelease");

    }
}
