using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [NonSerialized] public static Health health;
    void Start()
    {
        health = GetComponent<Health>();
        health.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
