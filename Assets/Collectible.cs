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
    /// <summary>
    /// Type of collectible, either Health or Money
    /// </summary>
    public CollectibleType Type;
    /// <summary>
    /// Ammount of collectible got, once its collected
    /// </summary>
    public int ValueWhenCatched;
    /// <summary>
    /// Sound of collectible, once its caught
    /// </summary>
    AudioSource AudioSource;
    /// <summary>
    /// Checking if collectible is while destroying process
    /// </summary>
    bool whileDestroying;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        //Checking if collectible collides with player
        if (collision.gameObject.name == "Player" && !whileDestroying)
        {
            //Checking for type of collectible that collided with user and doing an action accordingly to it
            if(Type == CollectibleType.Health)
            {
                StartCoroutine(DestroyHealthCollectible());
            }else if(Type == CollectibleType.Money)
            {
                StartCoroutine(DestroyMoneyCollectible());
            }
        }
    }
    /// <summary>
    /// Destroying collectible item that gives health
    /// </summary>
    /// <returns></returns>
    IEnumerator DestroyHealthCollectible()
    {
        whileDestroying = true;
        GetComponent<MeshCollider>().enabled = false;
        AudioSource.Play();
        FindObjectOfType<HealthController>().Health += ValueWhenCatched;
        yield return new WaitWhile(() => AudioSource.isPlaying);
        Destroy(gameObject);
    }
    /// <summary>
    /// Destroying collectible item that gives money
    /// </summary>
    /// <returns></returns>
    IEnumerator DestroyMoneyCollectible()
    {
        whileDestroying = true;
        GetComponent<MeshCollider>().enabled = false;
        AudioSource.Play();
        GameManager.money += ValueWhenCatched;
        yield return new WaitWhile(() => AudioSource.isPlaying);
        Destroy(gameObject);
    }
}
