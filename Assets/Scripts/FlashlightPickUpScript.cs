using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightPickUpScript : MonoBehaviour
{

  //  public GameObject PickUpText;
    public GameObject FlashLightOnPlayer;

    void Start()
    {
        FlashLightOnPlayer.SetActive(false);
       // PickUpText.SetActive(false);
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
           // PickUpText.SetActive(true);
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
                //PickUpText.SetActive(false);
                
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
       // PickUpText.SetActive(false);
    }

    
}
