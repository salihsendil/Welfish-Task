using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    private void Start()
    {
        moveSpeed = 10;
    }

    public override void OnTriggerEnter(Collider other)
    {
        damage = 40;
        if (other.gameObject.tag == "Player") {
            other.GetComponent<Health>().TakeDamage(this.damage);
            Destroy(gameObject);
        }
    }

}
