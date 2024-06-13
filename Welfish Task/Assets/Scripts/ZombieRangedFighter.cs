using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieRangedFighter : ZombieBase
{

    [SerializeField] GameObject spell;
    [SerializeField] Transform spellPoint;

    public override void Update()
    {
        base.Update();
        moveSpeed = 6f;
        Debug.Log(CalculateDistanceToPlayer());
        AttackTarget();
    }

    public override void AttackTarget()
    {
        attackRange = 15f;
        if (attackRange >= CalculateDistanceToPlayer()) {
            animator.SetBool(isAttackingHash, true);
        }
        else {
            animator.SetBool(isAttackingHash, false);
        }
    }

    void Fire()
    {
        Instantiate(spell, spellPoint.position, transform.rotation);
    }

}
