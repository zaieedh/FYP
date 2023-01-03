using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool IsDead;
    public int Health;
    public int Damage;
    
    public float AttackDistance;
    public float WalkTowardsPlayerDistance;
    public float RunTowardsPlayerDistance;
    
    public float AttackSpeed;
    public float WalkSpeed;
    public float RunSpeed;

    public string WalkAnimationName;
    public string RunAnimationName;
    public string AttackAnimationName;

    private GameObject Player;

    public void Start()
    {
        Player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (!IsDead)
        {
            float distanceFromEnemyToPlayer = Mathf.Pow(Mathf.Pow((transform.position.x - Player.transform.position.x), 2) + Mathf.Pow((transform.position.z - Player.transform.position.z), 2), 0.5f);
            if (distanceFromEnemyToPlayer < AttackDistance)
            {
                AttackPlayer();
            }
            else if (distanceFromEnemyToPlayer < RunTowardsPlayerDistance)
            {
                RunTowardPlayer();
            }
            else if (distanceFromEnemyToPlayer < WalkTowardsPlayerDistance)
            {
                WalkTowardPlayer();
            }
        }
    }

    private void AttackPlayer()
    {
        GetComponent<Animation>().Play(AttackAnimationName);
        transform.LookAt(Player.transform);
    }

    private void RunTowardPlayer()
    {
        MoveTowardPlayer(RunAnimationName, RunSpeed);
    }

    private void WalkTowardPlayer()
    {
        MoveTowardPlayer(WalkAnimationName, WalkSpeed);
    }

    private void MoveTowardPlayer(string animationName, float speed)
    {
        GetComponent<Animation>().Play(animationName);
        transform.LookAt(Player.transform);
        transform.position = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x - 1, Player.transform.position.y - 1, Player.transform.position.z - 1), Time.deltaTime * speed);
    }
}
