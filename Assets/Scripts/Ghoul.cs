using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghoul : Enemy
{
    /// <summary>
    /// Checking if attack started
    /// </summary>
    bool AttackStarted;
    /// <summary>
    /// Dealing damage to player once it gets in contact with enemy
    /// </summary>
    /// <returns></returns>
    IEnumerator Attack()
    {
        AttackStarted = true;
        HealthController.TakeDamage(10);
        yield return new WaitForSeconds(1);
        AttackStarted = false;
    }
}
