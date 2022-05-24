using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPound : MonoBehaviour
{
    public static GroundPound gp;
    private Rigidbody2D rb;
    private PlayerMovement pm;
    private bool groundPound;
    public float stopTime = 0.5f;

    [SerializeField]
    public float dropForce = 20f;

    [SerializeField]
    private float gravityScale = 2f;

    public bool isGroundPounding = false;

    private bool ref_isGrounded;

    

    // Start is called before the first frame update

    private void Awake()
    {
        gp = this;
        pm = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {      

        ref_isGrounded = pm.isGrounded;

        if(ref_isGrounded)
        {
            pm.enabled = true;
        }
        

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!ref_isGrounded)
            {
                groundPound = true;
            }
        }
    }

  

    private void FixedUpdate()
    {
        if (groundPound && !isGroundPounding && !GetComponent<LadderMovement>().isLadder)
        {
            GroundPoundAttack();
        }
        groundPound = false;
    }
    private void GroundPoundAttack()
    {
        isGroundPounding = true;
        pm.enabled = false;
        StopAndSpin();
        StartCoroutine(DropAndSmash());
    }

    private void StopAndSpin()
    {
        ClearForces();
        rb.gravityScale = 0;

    }


    private IEnumerator DropAndSmash()
    {
        yield return new WaitForSeconds(stopTime);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.AddForce(Vector2.down * dropForce, ForceMode2D.Impulse);
    }

    private void ClearForces()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y >= 0.5)   // somente o contato de colisão com o eixo Y da força normal
        {
            if (collision.gameObject.layer == 10 && isGroundPounding)
            {
                Destroy(collision.gameObject);
            }

            CompleteGroundPound();
        }

       if (collision.collider.name == "Ground" )
        {
           

            CompleteGroundPound();  
        }
    }

    private void CompleteGroundPound()
    {
        rb.gravityScale = gravityScale;
        pm.enabled = true;
        isGroundPounding = false;
    }
}
