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
    AudioSource AudioSource;
    bool whileDestroying;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player" && !whileDestroying)
        {
            if(Type == CollectibleType.Health)
            {
                StartCoroutine(DestroyHealthCollectible());
            }else if(Type == CollectibleType.Money)
            {
                StartCoroutine(DestroyMoneyCollectible());
            }
        }
    }
    //Destroying collectible item that gives health
    IEnumerator DestroyHealthCollectible()
    {
        whileDestroying = true;
        GetComponent<MeshCollider>().enabled = false;
        AudioSource.Play();
        HealthController.Health += ValueWhenCatched;
        yield return new WaitWhile(() => AudioSource.isPlaying);
        Destroy(gameObject);
    }
    //Destroying collectible item that gives money
    IEnumerator DestroyMoneyCollectible()
    {
        whileDestroying = true;
        GetComponent<MeshCollider>().enabled = false;
        AudioSource.Play();
        Scene_one_controller.money += ValueWhenCatched;
        yield return new WaitWhile(() => AudioSource.isPlaying);
        Destroy(gameObject);
    }
}
