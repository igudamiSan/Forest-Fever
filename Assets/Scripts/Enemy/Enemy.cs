using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] int maxHealth;
    
    public float speed = 1f,attackRange=1f,damage=3f,hitDelay=1f;
    public bool alerted = false;
    private NavMeshAgent agent;
    private GameObject player;
    [NonSerialized] public bool inAttackRange = false;
    [NonSerialized] public Health health;
   
    void Start()
    {
        health= GetComponent<Health>();
        health.SetMaxHealth(maxHealth);

        agent = GetComponent<NavMeshAgent>();   
        agent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (alerted && !inAttackRange)
        {
            //move for attacking player
            agent.SetDestination(PlayerMove.position);
        }
        else if (alerted && inAttackRange)
        {
            //ready to attack player
            agent.velocity = Vector3.zero;
            StartCoroutine(HitPlayer());
            
        }
        else
        {
            //move idly
        }
        if (health.dead) { 
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Player")
        {    
            inAttackRange = true;
        }
    }
    private void OnTriggerExit(Collider obj)
    {
        if (obj.tag == "Player")
        {
            inAttackRange = false;
        }
    }

    IEnumerator HitPlayer() {
        yield return new WaitForSeconds(hitDelay);
        PlayerHealth.health.takeDamage(damage);
    }

}
