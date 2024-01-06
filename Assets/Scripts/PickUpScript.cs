using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
//    // public ItemScript itemscript;
//     public Rigidbody rb;
//     public BoxCollider coll;
//     public Transform player, gunContainer, fpsCam;
//     public float pickUpRange, dropForwardForce, dropUpwardForce;
//     public bool equipped;
//     public static bool slotFull;

//     // Update is called once per frame
//     void Update()
//     {
//         //check if player is in range and E is pressed
//         Vector3 distanceToPlayer=player.position-transform.position;
//         if(!equipped && distanceToPlayer.magnitude<=pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
//             PickUp();

//         //drop if equipped and Q is pressed
//         if(equipped && Input.GetKeyDown(KeyCode.Q))
//             Drop();
//     }

//     private void PickUp()
//     {
//         equipped=true;
//         slotFull=true;

//         //Make Rigidbody kinematic and BoxCollider a trigger
//         rb.isKinematic=true;
//         coll.isTrigger=true;

//         //Enable script
//      //   itemscript.enabled=true;

//     }

//     private void Drop()
//     {
//         equipped=false;
//         slotFull=false;

//         //Make Rigidbody not kinematic and BoxCollider normal
//         rb.isKinematic=false;
//         coll.isTrigger=false;

//         //Disable script
//       //  itemscript.enabled=false;

//     }





//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

    public GameObject PickUpText;
    public GameObject FlashLightOnPlayer;

    void Start()
    {
        FlashLightOnPlayer.SetActive(false);
        PickUpText.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PickUpText.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        

        if(other.gameObject.tag == "Player")
        {
            if(Input.GetKey(KeyCode.E))
            {
                FlashLightOnPlayer.SetActive(true);

                
                this.gameObject.SetActive(false); //disabling flashlight
                PickUpText.SetActive(false);
                
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        PickUpText.SetActive(false);
    }

    
}
