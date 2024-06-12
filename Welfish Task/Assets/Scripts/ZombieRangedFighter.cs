using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieRangedFighter : ZombieBase
{
    float attackRange = 15f;

    public override void Update()
    {
        base.Update();
        Debug.Log(CalculateDistanceToPlayer());
        CalculateDistanceToPlayer();
        AttackTarget();
    }

    public override void AttackTarget()
    {
        if (enemy.stoppingDistance >= CalculateDistanceToPlayer()) {
            Debug.LogWarning("saldýrýyom");
        }
    }


    float CalculateDistanceToPlayer()
    {
        float distance = Vector3.Distance(transform.position, playerController.transform.position);
        return distance;
    }
}
