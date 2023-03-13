using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
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
}
