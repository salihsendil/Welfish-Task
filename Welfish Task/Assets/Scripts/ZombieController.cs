using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    Animator animator;
    int isAttackingHash;
    public NavMeshAgent enemy;
    PlayerController playerController;
    [SerializeField] AudioClip hitSfx;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        animator = GetComponent<Animator>();

        isAttackingHash = Animator.StringToHash("isAttacking");
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(playerController.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player") {
            animator.SetBool(isAttackingHash, true);
        }
        else {
            animator.SetBool(isAttackingHash, false);
        }

        if (other.tag == "Projectile") {
            AudioSource.PlayClipAtPoint(hitSfx, transform.position, 1.3f);
            Debug.Log("zombie evet");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") {
            animator.SetBool(isAttackingHash, false);
        }
    }


}
