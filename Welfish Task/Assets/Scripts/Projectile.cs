using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float destroyDelay = 4f;
    float moveSpeed = 30f;
    int damage = 35;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        Destroy(gameObject, destroyDelay);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy") {
            //give damage decrease
            other.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
