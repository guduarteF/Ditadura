using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventorySystem : MonoBehaviour
{
    public GameObject[] pickableItens;
    public GameObject cam;
    public GameObject E_to_PickUp;
    public Text E_to_PickUp_txt;

    public GameObject[] Slot_backg;
    public GameObject[] Slot_icon;
    public bool[] Slot_pressed;

    private int[] slots;

    private int x;

    [SerializeField]
    public Item[] items;

    public Transform LeftHandSpawn;

    public GameObject Lighter_prefab;

    

    private void Awake()
    { 
        for (int j = 0; j < pickableItens.Length; j++)
        {
                items[j].name = pickableItens[j].gameObject.name;
                items[j].itemObject = pickableItens[j].gameObject;
                items[j].icon = pickableItens[j].GetComponent<imageSource>().img;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        Slot_pressed = new bool[4];
        slots = new int[4];

        slots[0] = 0;
        slots[1] = 0;
        slots[2] = 0;
        slots[3] = 0;
    }

    // Update is called once per frame
    void Update()
    {
       

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.DrawRay(cam.transform.position,cam.transform.forward, Color.red);

        if (Physics.Raycast(raio, out hit, 1f))
        {
            // O raio está indo em direção ao mouse , quando ele não está preso na tela desorienta
            if (hit.collider.gameObject.CompareTag("pickableObject"))
            {
                E_to_PickUp.SetActive(true);
                E_to_PickUp_txt.text = "'E' to pickup";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    PickItem(hit);

                }
            }
            else
            {
                // as vezes não esta desativando mesmo quando o raio para de colidir 'bug'
                E_to_PickUp.SetActive(false);
            }

        }

        getPressedSlot();
    }

    public void PickItem(RaycastHit hit)
    { 
        if (hit.collider.gameObject.name == "Lighter")
        {
            EquipLighterSlot(hit);
        }
        else if(slots[1] == 0)
        {
            Equip_Slot1(hit);
        }
        else if(slots[2] == 0)
        {
            Equip_Slot2(hit);
            
        }
        else if(slots[3] == 0)
        {
            Equip_Slot3(hit);   
        }

        Debug.Log("Acertou o objeto de nome : " + hit.collider.gameObject);

        //remover o objeto de cena
        Destroy(hit.collider.gameObject);

        // instanciar ele na mão *como children de um gameobject mão*

    }

    public void DropItem()
    {

    }

    private void getPressedSlot()
    {
        // branco = no inventário mas não na mão
        // preto  = selecionou - selecionado - na mão (direita)
        // vermwelho = deselecionado -> muda pro branco

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Slot_pressed[0])
            {
                //Desequipar Slot Q
                SlotQDeselected();
            }
            else
            {
                // Equipar Slot Q
                SlotQSelected();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (Slot_pressed[1])
            {
                //Equipar Slot 1
                Slot1Deselected();
            }
            else
            {
                //Desequipar o Slot 2 e Slot 3
                Slot2Deselected();
                Slot3Deselected();

                //Equipar Slot 1
                Slot1Selected();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (Slot_pressed[2])
            {
                //Equipar o Slot 2
                Slot2Deselected();
            }
            else
            {
                //Desequipar o Slot 1 e Slot3
                Slot1Deselected();
                Slot3Deselected();

                //Equipar Slot 2
                Slot2Selected();
            }

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (Slot_pressed[3])
            {
                //Equipar o Slot 2
                Slot3Deselected();
            }
            else
            {
                //Desequipar o Slot 1 e Slot 2
                Slot1Deselected();
                Slot2Deselected();
                

                //Equipar Slot 2
                Slot3Selected();
            }
        }
    }

    //SLOT Q

    private void SlotQSelected()
    {
        Slot_backg[0].GetComponent<Animator>().SetBool("selected", true);
        Slot_backg[0].GetComponent<Animator>().SetBool("deselected", false);
        Slot_pressed[0] = true;
        PickUpLighter();
    }

    private void SlotQDeselected()
    {
        Slot_backg[0].GetComponent<Animator>().SetBool("deselected", true);
        Slot_backg[0].GetComponent<Animator>().SetBool("selected", false);
        Slot_pressed[0] = false;
        HideLighter();
    }

    //SLOT 1

    private void Slot1Selected()
    {
        Slot_backg[1].GetComponent<Animator>().SetBool("selected", true);
        Slot_backg[1].GetComponent<Animator>().SetBool("deselected", false);
        Slot_pressed[1] = true;
    }

    private void Slot1Deselected()
    {
        Slot_backg[1].GetComponent<Animator>().SetBool("deselected", true);
        Slot_backg[1].GetComponent<Animator>().SetBool("selected", false);
        Slot_pressed[1] = false;
    }



    // SLOT 2

    private void Slot2Selected()
    {
        Slot_backg[2].GetComponent<Animator>().SetBool("selected", true);
        Slot_backg[2].GetComponent<Animator>().SetBool("deselected", false);
        Slot_pressed[2] = true;
    }

    private void Slot2Deselected()
    {
        Slot_backg[2].GetComponent<Animator>().SetBool("deselected", true);
        Slot_backg[2].GetComponent<Animator>().SetBool("selected", false);
        Slot_pressed[2] = false;
    }

    // SLOT 3
    private void Slot3Selected()
    {
        Slot_backg[3].GetComponent<Animator>().SetBool("selected", true);
        Slot_backg[3].GetComponent<Animator>().SetBool("deselected", false);
        Slot_pressed[3] = true;
    }

    private void Slot3Deselected()
    {
        Slot_backg[3].GetComponent<Animator>().SetBool("deselected", true);
        Slot_backg[3].GetComponent<Animator>().SetBool("selected", false);
        Slot_pressed[3] = false;
    }

   
    // EQUIP ON SLOTS
    private void Equip_Slot1(RaycastHit hit)
    {
        slots[1] = 1;
        Slot_icon[1].GetComponent<Image>().sprite = hit.collider.gameObject.GetComponent<imageSource>().img;
    }

    private void Equip_Slot2(RaycastHit hit)
    {
        slots[2] = 1;
        Slot_icon[2].GetComponent<Image>().sprite = hit.collider.gameObject.GetComponent<imageSource>().img;
    }

    private void Equip_Slot3(RaycastHit hit)
    {
        slots[3] = 1;
        Slot_icon[3].GetComponent<Image>().sprite = hit.collider.gameObject.GetComponent<imageSource>().img;
    }

    private void EquipLighterSlot(RaycastHit hit)
    {
        slots[0] = 1;
        Slot_icon[0].GetComponent<Image>().sprite = hit.collider.gameObject.GetComponent<imageSource>().img;        
    }

    // PICK UP IN HAND

    private void PickUpLighter()
    {
        // Está instanciando com a rotação do player
        GameObject lighter = Instantiate(Lighter_prefab, LeftHandSpawn.position, Lighter_prefab.transform.rotation);
        lighter.transform.SetParent(LeftHandSpawn);
    }

    // HIDE ITEM

    private void HideLighter()
    {
        // animação de desequipar isqueiro
        GameObject lighter = GameObject.Find("Lighter LP(Clone)");
        Destroy(lighter); ;

    }
  
}
