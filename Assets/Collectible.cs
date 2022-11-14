using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectibleType
{
    Health,
    Money
}
public class Collectible : MonoBehaviour
{
    public CollectibleType Type;
    public int ValueWhenCatched;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if(Type == CollectibleType.Health)
            {
                HealthController.Health += ValueWhenCatched;
                Destroy(gameObject);
            }
        }
    }
}
