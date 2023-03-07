using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour
{
    public Rigidbody rb; 

    

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            rb.AddForce(-(rb.velocity.x), -(rb.velocity.y), -(rb.velocity.z), ForceMode.Impulse);
        }
    }
}
