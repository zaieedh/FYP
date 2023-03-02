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
        //If player collides with right arm of ghoul, it will take 5 dmg
        if(collision.collider.gameObject.name == "Character1_RightHand")
        {
            HealthController.TakeDamage(5);
        }
    }
}
