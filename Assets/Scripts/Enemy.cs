using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /// <summary>
    /// Check if enemy is dead
    /// </summary>
    public bool IsDead;
    /// <summary>
    /// Health of enemy
    /// </summary>
    public int Health;
    /// <summary>
    /// Damage enemy deals
    /// </summary>
    public int Damage;
    /// <summary>
    /// Distance of enemy's attacks
    /// </summary>
    public float AttackDistance;
    /// <summary>
    /// Distance of when to trigger an anemy to walk towards player (if player gets close to enemy on this distance, enemy will start walking to him)
    /// </summary>
    public float WalkTowardsPlayerDistance;
	/// <summary>
	/// Distance of when to trigger an anemy to run towards player (if player gets close to enemy on this distance, enemy will start running to him)
	/// </summary>
	public float RunTowardsPlayerDistance;
    
    /// <summary>
    /// Enemy's attack speed
    /// </summary>
    public float AttackSpeed;
    /// <summary>
    /// Enemy's walk speed
    /// </summary>
    public float WalkSpeed;
    /// <summary>
    /// Enemy's run speed
    /// </summary>
    public float RunSpeed;

    /// <summary>
    /// Name of enemy's walk animation
    /// </summary>
    public string WalkAnimationName;
    /// <summary>
    /// Name of enemy's run animation
    /// </summary>
    public string RunAnimationName;
    /// <summary>
    /// Name of enemy's attack animation
    /// </summary>
    public string AttackAnimationName;
    /// <summary>
    /// Instance of player's object
    /// </summary>
    private GameObject Player;

    public void Start()
    {
        Player = GameObject.Find("Player");
    }

    private void Update()
    {
        //Proceeding enemies actions based on distance to player if enemy is not dead
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
    /// <summary>
    /// Playing enemy's attack animation and attacking player
    /// </summary>
    private void AttackPlayer()
    {
        GetComponent<Animation>().Play(AttackAnimationName);
        transform.LookAt(Player.transform);
    }
    /// <summary>
    /// Running towards player
    /// </summary>
    private void RunTowardPlayer()
    {
        MoveTowardPlayer(RunAnimationName, RunSpeed);
    }
    /// <summary>
    /// Walking towards player
    /// </summary>
    private void WalkTowardPlayer()
    {
        MoveTowardPlayer(WalkAnimationName, WalkSpeed);
    }
    /// <summary>
    /// Moving towards player
    /// </summary>
    /// <param name="animationName">Animation played while moving</param>
    /// <param name="speed">Speed of moving</param>
    private void MoveTowardPlayer(string animationName, float speed)
    {
        GetComponent<Animation>().Play(animationName);
        transform.LookAt(Player.transform);
        transform.position = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x - 1, Player.transform.position.y - 1, Player.transform.position.z - 1), Time.deltaTime * speed);
    }
}
