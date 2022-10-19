using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light Banheiro, Reuniao, CorredorFim , CorredorFim2, CorredorInicio,CorredorInicio2, Chefe;
    public bool _banheiro, _reuniao, _corredor_Inicio,_corredor_Fim, _chefe;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LightisTurnOn();
       
    }

    // Verificar se a luz está ligada

    public void LightisTurnOn()
    {
        if (Reuniao.enabled == true)
        {
            _reuniao = true;
        }
        else if (Banheiro.enabled == true)
        {
            _banheiro = true;
        }
        else if (Chefe.enabled == true)
        {
            _chefe = true;
        }
        else if (CorredorFim == true)
        {
            _corredor_Fim = true;
        }      
        else if (CorredorInicio == true)
        {
            _corredor_Inicio = true;
        }
        
    }


    // CONTROLE DA LUZ POR COMODO

    public void Sala_De_Reuniao(bool Ligado)
    {
        if(Ligado)
        {
            Reuniao.enabled = true;
            
        }
        else
        {
            Reuniao.enabled = false;
            _reuniao = false;
        }
    }

   
    public void Banheiro_luz(bool Ligado)
    {
        if (Ligado)
        {
            Banheiro.enabled = true;
            
        }
        else
        {
            Banheiro.enabled = false;
            _banheiro = false;
        }
    }   

    public void Sala_Do_Chefe(bool Ligado)
    {
        if (Ligado)
        {
            Chefe.enabled = true;
            
        }
        else
        {
            Chefe.enabled = false;
            _chefe = false;
        }
    } 

    public void Corredor_Fim(bool Ligado)
    {
        if (Ligado)
        {
            CorredorFim.enabled = true;
            CorredorFim2.enabled = true;
           
        }
        else
        {
            CorredorFim.enabled = false;
            CorredorFim2.enabled = false;
            _corredor_Fim = false;
        }
    }
    public void Corredor_Inicio(bool Ligado)
    {
        if (Ligado)
        {
            CorredorInicio.enabled = true;
            CorredorInicio2.enabled = true;
           
            

        }
        else
        {
            CorredorInicio.enabled = false;
            CorredorInicio2.enabled = false;
            _corredor_Inicio = false;
        }
    }




}
