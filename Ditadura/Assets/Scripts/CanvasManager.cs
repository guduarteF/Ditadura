using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public InputField InputFieldVelocity;
    public InputField InputFieldImpulso;
    public InputField InputFieldGpForce;
    public InputField InputFieldMassa;
    public InputField InputFieldGravidade;

    public GameObject Player;

    public static CanvasManager cm;
    public Text txt_coin;
    public GameObject PauseScreen;
    public bool pausado;

    // Start is called before the first frame update
    void Start()
    {
        cm = this;
        pausado = false;
        Debug.Log(InputFieldVelocity.text);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if(pausado)
            {
                VoltarProJogo();
                pausado = false;
            }
            else
            {
                Pausar();
                pausado = true;
            }
            
        }
        
       
        
    }

    public void ApplyInputsToValues()
    {     
        //VELOCIDADE
        float input_veloc;       
        input_veloc = float.Parse(InputFieldVelocity.text);
        PlayerMovement.playermov.velocity = input_veloc;


        //IMPULSO
        float input_impulso;
        input_impulso = float.Parse(InputFieldImpulso.text);
        PlayerMovement.playermov.impulse = input_impulso;

        // Força do Gp
        float input_GpForce;
        input_GpForce = float.Parse(InputFieldGpForce.text);
        GroundPound.gp.dropForce = input_GpForce;

        // Massa
        float input_massa;
        input_massa = float.Parse(InputFieldMassa.text);
        Player.GetComponent<Rigidbody2D>().mass = input_massa;

        // Gravidade
        float input_gravity;
        input_gravity = float.Parse(InputFieldGpForce.text);
        Player.GetComponent<Rigidbody2D>().gravityScale = input_gravity;



    }
    
    public void Pausar()
    {
        PauseScreen.SetActive(true);
    }
    
    public void SairDoJogo()
    {
        Application.Quit();
    }

    public void VoltarProJogo()
    {
        PauseScreen.SetActive(false);
    }
}
