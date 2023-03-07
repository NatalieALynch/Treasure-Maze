using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 
public class BullMovement : MonoBehaviour
{
    public float wanderTimer = 5f;
    private float timer;
 
    public float lookRadius = 10f;
 
    public NavMeshAgent agent;
    public Transform target;
    public bool isChasingPlayer;
    public float x;
    public float y;
    public float z;
 
    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
         x = Random.Range(0,100);
         y = 1.1f;
         z = Random.Range(0, 100);
        Vector3 pos = new Vector3(x, y, z);
        agent.SetDestination(pos);
    }
 
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
 
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            isChasingPlayer = true;
        }
        else
        {
            isChasingPlayer = false;
        }
 
        if(isChasingPlayer == false)
        {
            timer += Time.deltaTime;
           
            if(timer >= wanderTimer)
            {
                 x = Random.Range(-25,25);
                 y = 1.1f;
                 z = Random.Range(-25, 26);
                Vector3 pos = new Vector3(x, y, z);

                agent.SetDestination(pos);
                timer = 0;
            }
        }
        else
        {
            timer = 0;
        }
    }

 
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}