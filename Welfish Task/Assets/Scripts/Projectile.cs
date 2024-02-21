using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float destroyDelay = 3f;
    float moveSpeed = 40f;
    int damage = 35;

    void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        Destroy(gameObject, destroyDelay);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy") {
            other.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
