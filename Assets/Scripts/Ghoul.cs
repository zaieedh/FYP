using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghoul : MonoBehaviour
{
    public bool IsDead;
    public GameObject Player;

    public void Start()
    {
        Player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (!IsDead)
        {
            float distanceFromGhoulToPlayer = Mathf.Pow(Mathf.Pow((transform.position.x - Player.transform.position.x), 2) + Mathf.Pow((transform.position.z - Player.transform.position.z), 2), 0.5f);
            if (distanceFromGhoulToPlayer < 10)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x - 1, Player.transform.position.y - 1, Player.transform.position.z - 1), Time.deltaTime * 0.1f);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!IsDead)
        {
            if (collision.gameObject.name == "Player")
            {
                HealthController.Health -= 10;
            }
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (!IsDead)
        {
            if (collision.gameObject.name == "Player")
            {
                HealthController.Health -= 1;
            }
        }
    }
}
