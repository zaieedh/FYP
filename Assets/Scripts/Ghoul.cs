using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghoul : MonoBehaviour
{
    public bool IsDead;
    private GameObject Player;

    public void Start()
    {
        Player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (!IsDead)
        {
            float distanceFromGhoulToPlayer = Mathf.Pow(Mathf.Pow((transform.position.x - Player.transform.position.x), 2) + Mathf.Pow((transform.position.z - Player.transform.position.z), 2), 0.5f);
            if (distanceFromGhoulToPlayer < 2.5)
            {
                GetComponent<Animation>().Play("Attack1");
                transform.LookAt(Player.transform);
                //transform.position = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x - 1, Player.transform.position.y - 1, Player.transform.position.z - 1), Time.deltaTime * 0.5f);
            }else if (distanceFromGhoulToPlayer < 10)
            {
                GetComponent<Animation>().Play("Run");
                transform.LookAt(Player.transform);
                transform.position = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x - 1, Player.transform.position.y - 1, Player.transform.position.z - 1), Time.deltaTime * 0.3f);
            }else if(distanceFromGhoulToPlayer < 20)
            {
                GetComponent<Animation>().Play("Walk");
                transform.LookAt(Player.transform);
                transform.position = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x - 1, Player.transform.position.y - 1, Player.transform.position.z - 1), Time.deltaTime * 0.1f);
            }
        }
    }

    bool AttackStarted;

    void OnCollisionStay(Collision collision)
    {
        /*if (!IsDead)
        {
            if (collision.gameObject.name == "Player")
            {
                if (!AttackStarted)
                {
                    StartCoroutine(Attack());
                }
            }
        }*/
    }

    IEnumerator Attack()
    {
        AttackStarted = true;
        HealthController.Health -= 10;
        yield return new WaitForSeconds(1);
        AttackStarted = false;
    }
}
