using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    protected float destroyDelay = 3f;
    protected float moveSpeed = 40f;
    protected int damage = 35;

    protected void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        Destroy(gameObject, destroyDelay);
    }

    virtual public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy") {
            other.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
