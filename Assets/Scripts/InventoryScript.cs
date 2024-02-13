using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{

    [SerializeField] public static int maxSlots=6;
    public static Item[] Inventory=new Item[maxSlots];
    public static int slotsFilled=-1;
    private int EquippedSlot=1;
    public GameObject InventoryPanel;
    public InventorySlot[] slot = new InventorySlot[6];


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Drop();
    }

    void Drop()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Vector3 pos = new Vector3();
            pos = PlayerMove.position + PlayerMove.forward * 2f;
            Instantiate(Inventory[slotsFilled].gameObject, pos, Quaternion.identity );
            Inventory[slotsFilled].gameObject.SetActive(true);
            slotsFilled--;
        }
    }
}
