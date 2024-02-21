using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int baseHealth = 100;
    [SerializeField] int currentHealth;

    public int BaseHealth { get => baseHealth;}
    public int CurrentHealth { get => currentHealth;}

    void Start()
    {
        currentHealth = baseHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) {
            Destroy(gameObject);
        }
    }
}
