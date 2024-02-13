using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int maxHealth;

    public bool alerted = false;
    [NonSerialized] public Health health;
    // Start is called before the first frame update
    void Start()
    {
        health= GetComponent<Health>();
        health.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (alerted)
        {
            //move for attacking player 
        }
        else { 
            //move idly
        }
        if (health.dead) { 
            gameObject.SetActive(false);
        }
    }
}
