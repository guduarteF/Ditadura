using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlueButton : MonoBehaviour
{
    public static BlueButton bb;
    public UnityEvent OnPressed;
    public UnityEvent OnReleased;

    // Start is called before the first frame update
    void Start()
    {
        bb = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pressed()
    {
        OnPressed.Invoke();
    }

    public void Released()
    {
        OnReleased.Invoke();
    }
}
