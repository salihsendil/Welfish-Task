using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplayer : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    PlayerController playerController;
    Health playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        playerHealth = playerController.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = playerHealth.CurrentHealth;
    }
}
