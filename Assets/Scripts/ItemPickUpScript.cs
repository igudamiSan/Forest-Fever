using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUpScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        
        if ((other.gameObject.tag == "Player")&&(Input.GetKey(KeyCode.E))&&(InventoryScript.slotsFilled <InventoryScript.maxSlots))
        {
            print("shakeeela");
            InventoryScript.slotsFilled++;
            InventoryScript.Inventory[InventoryScript.slotsFilled] = gameObject.GetComponent<Item>();
      
            print(InventoryScript.Inventory[InventoryScript.slotsFilled].gameObject.name);
            
            gameObject.SetActive(false);

        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
