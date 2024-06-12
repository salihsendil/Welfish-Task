using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMeleeFighter : ZombieBase
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            animator.SetBool(isAttackingHash, true);
            target = other.gameObject;
        }
        else {
            animator.SetBool(isAttackingHash, false);
        }

        if (other.tag == "Projectile") {
            AudioSource.PlayClipAtPoint(hitSfx, transform.position, 1.3f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") {
            animator.SetBool(isAttackingHash, false);
            target = other.gameObject;
        }
    }

}
