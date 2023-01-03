using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    
    private void Start()
    {
        GetComponent<Rigidbody>().sleepThreshold = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.name == "Character1_RightHand")
        {
            HealthController.Health -= 5;
        }
    }
}
