using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghoul : Enemy
{
    bool AttackStarted;

    IEnumerator Attack()
    {
        AttackStarted = true;
        HealthController.TakeDamage(10);
        yield return new WaitForSeconds(1);
        AttackStarted = false;
    }
}
