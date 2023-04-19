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
        //Assigning AudioSource component from object to variable AudioSource
        AudioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        //Checking if collectible collides with player
        if (collision.gameObject.name == "Player" && !whileDestroying)
        {
			//Checking for type of collectible that collided with user and doing an action accordingly to it
			StartCoroutine(DestroyCollectible());
		}
    }
    /// <summary>
    /// Destroying collectible item and base on its type, increasing either money or health
    /// </summary>
    /// <returns></returns>
    IEnumerator DestroyCollectible()
    {
        //
        whileDestroying = true;
        GetComponent<MeshCollider>().enabled = false;
        AudioSource.Play();

		if (Type == CollectibleType.Health)
		{
            IncreaseHealth();
		}
		else if (Type == CollectibleType.Money)
		{
            IncreaseMoney();
		}

        yield return new WaitWhile(() => AudioSource.isPlaying);
        Destroy(gameObject);
    }

    /// <summary>
    /// Increasing health by assigned value in ValueWhenCatched variable
    /// </summary>
    void IncreaseHealth()
    {
		FindObjectOfType<HealthController>().Health += ValueWhenCatched;
	}
    /// <summary>
    /// Increasing money by assigned vlaue in ValueWhenCatched variable
    /// </summary>
    void IncreaseMoney()
    {
		GameManager.money += ValueWhenCatched;
	}
}
