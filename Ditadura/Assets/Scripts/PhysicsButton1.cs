using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsButton1 : MonoBehaviour
{
    public Transform buttonTop;
    public Transform buttonLowerLimit;
    public Transform buttonUpperLimit;
    public float treshHold;
    public float force ;
    private float upperLowerDiff;
    public bool isPressed;
    private bool prevPressedState;
    public UnityEvent onPressed;
    public UnityEvent OnReleased;

    void Start()
    {
        Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), buttonTop.GetComponent<BoxCollider2D>());

        if(transform.eulerAngles != Vector3.zero)
        {
            Vector3 savedAngle = transform.eulerAngles;
            transform.eulerAngles = Vector3.zero;
            upperLowerDiff = buttonUpperLimit.position.y - buttonLowerLimit.position.y;
            transform.eulerAngles = savedAngle;
        }
        else
        {
            upperLowerDiff = buttonUpperLimit.position.y - buttonLowerLimit.position.y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        buttonTop.transform.localPosition = new Vector3(0, buttonTop.transform.localPosition.y, 0);
        buttonTop.transform.localEulerAngles = new Vector3(0, 0, 0);

        if(buttonTop.localPosition.y >= 0)
        {
            buttonTop.transform.position = new Vector3(buttonUpperLimit.position.x, buttonUpperLimit.position.y, buttonUpperLimit.position.z); ;
        }
        else
        {
            buttonTop.GetComponent<Rigidbody2D>().AddForce(buttonTop.transform.up * force * Time.fixedDeltaTime);
        }

        if(buttonTop.localPosition.y <= buttonLowerLimit.localPosition.y)
        {
            buttonTop.transform.position = new Vector3(buttonLowerLimit.position.x, buttonLowerLimit.position.y, buttonLowerLimit.position.z);
        }

        if(Vector3.Distance(buttonTop.position, buttonLowerLimit.position) < upperLowerDiff * treshHold)
        {
            isPressed = true;
        }
        else
        {
            isPressed = false;
        }

        if(isPressed && prevPressedState != isPressed)
        {
            Pressed();
        }

        if(!isPressed && prevPressedState != isPressed)
        {
            Released();
        }

        void Pressed()
        {
            prevPressedState = isPressed;
            onPressed.Invoke();
        }

        void Released()
        {
            prevPressedState = isPressed;
            OnReleased.Invoke();
        }


    }
}
