using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public bool InsideRussianCheckpoint { get; set; }
	private void Awake()
	{
		DontDestroyOnLoad(this);
	}
	private void Start()
    {
        GetComponent<Rigidbody>().sleepThreshold = 0;
    }

    public void MoveTo(Vector3 position)
    {
        transform.position = position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var enemy = (collision.collider.gameObject.GetComponentInParent(typeof(Enemy)) as Enemy);
		if (enemy != null)
        {
            GetComponent<HealthController>().TakeDamage(enemy.Damage);
        }
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "RussianRadioCheckpoint")
		{
			InsideRussianCheckpoint = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "RussianRadioCheckpoint")
		{
			InsideRussianCheckpoint = false;
		}
	}
}
