using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{   
    float maxHealth=0;
    float curHealth;
    [NonSerialized] public bool dead = false;
    // Start is called before the first frame update

    public void SetMaxHealth(float max) { 
        maxHealth= max;
        resetHealth();
    }

    void Start()
    {
        curHealth = maxHealth;
        
    }

    public void takeDamage(float hp) {
        curHealth -= hp;
        if (curHealth < 0) { 
            curHealth= 0;
        }
    }

    public void takeHealth(float hp) {
        curHealth += hp;
        if (curHealth > maxHealth) {
            curHealth = maxHealth;
        }
    }

    public void resetHealth() {
        curHealth = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        if (curHealth == 0) { 
            dead= true;
        }
        print(curHealth);
    }
}
