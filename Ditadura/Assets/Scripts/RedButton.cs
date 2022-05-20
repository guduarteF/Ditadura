using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RedButton : MonoBehaviour
{
    public static RedButton rb;

    public UnityEvent OnPressed;
    public UnityEvent OnReleased;

    // Start is called before the first frame update
    void Start()
    {
        rb = this;
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
