using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int baseHealth = 100;
    [SerializeField] int currentHealth;

    public int BaseHealth { get => baseHealth;}
    public int CurrentHealth { get => currentHealth;}


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = baseHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) {
            Destroy(gameObject);
        }
    }
}
