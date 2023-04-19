using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	/// <summary>
	/// Checking if player is inside russian's radio checkpoint
	/// </summary>
    public bool InsideRussianCheckpoint { get; set; }

	private void Start()
    {
        GetComponent<Rigidbody>().sleepThreshold = 0;
    }

	/// <summary>
	/// Moving player to given position
	/// </summary>
	/// <param name="position">Position to move player to</param>
    public void MoveTo(Vector3 position)
    {
        transform.position = position;
    }

    private void OnCollisionEnter(Collision collision)
    {
		//Checking if player collides with enemy, if he does, he will take damage from enemy
        var enemy = (collision.collider.gameObject.GetComponentInParent(typeof(Enemy)) as Enemy);
		if (enemy != null)
        {
            GetComponent<HealthController>().TakeDamage(enemy.Damage);
        }
    }

	private void OnTriggerEnter(Collider other)
	{
		//Checking if player started colliding with RussianRadioCheckpoint and updating related quest 
		if (other.gameObject.name == "RussianRadioCheckpoint")
		{
			InsideRussianCheckpoint = true;
			var sceneOneController = FindObjectOfType<PlayerRaycastController>();
			sceneOneController.questsManager.GetQuestByName("Second Quest").GetTaskByName("Find signal").IsCompleted = true;
			sceneOneController.questsGuiManager.UpdateGUI();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		//Checking if player ended collidign with RussianRadioCheckpoint
		if (other.gameObject.name == "RussianRadioCheckpoint")
		{
			InsideRussianCheckpoint = false;
		}
	}
}
