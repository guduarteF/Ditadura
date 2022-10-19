using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSimpleMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;

    CharacterController _characterController;
    public bool isGrounded;

    private void Awake() => _characterController = GetComponent<CharacterController>();

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical);
        Vector3 movement = transform.TransformDirection(direction) * _moveSpeed;
        isGrounded = _characterController.SimpleMove(movement);
    }

    private void Update()
    {
        RevealItem();
    }

    private void RevealItem()
    {
        LightController LightScript = GameObject.Find("luz").transform.Find("_LightController").GetComponent<LightController>();
        InventorySystem InventoryScript = GetComponent<InventorySystem>();
        GameObject ItemRevealParticle = GameObject.Find("RevealedItemParticle").gameObject;


        if (LightScript._banheiro == false && InventoryScript.Slot_pressed[0] == true)
        {
           

            if(!ItemRevealParticle.GetComponent<ParticleSystem>().isPlaying)
            {
                ItemRevealParticle.GetComponent<ParticleSystem>().Play();
            }

           
           
            
        }
        else
        {
            ItemRevealParticle.GetComponent<ParticleSystem>().Stop();
           
        }

    }
}
