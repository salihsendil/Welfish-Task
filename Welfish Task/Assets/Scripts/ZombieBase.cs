using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class ZombieBase : MonoBehaviour
{
    protected Animator animator;
    protected int isAttackingHash;
    protected PlayerController playerController;
    public AudioClip hitSfx;
    public GameObject target;
    protected ScoreKeeper scoreKeeper;
    public int attackDamage = 15;
    public int killScore = 50;

    float distance;
    protected float attackRange = 1f;
    protected float moveSpeed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        animator = GetComponent<Animator>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

        isAttackingHash = Animator.StringToHash("isAttacking");
    }

    // Update is called once per frame
    virtual public void Update()
    {
        transform.LookAt(playerController.transform.position);
        Chase();
        Stop();
    }
    protected void Chase()
    {
        if (CalculateDistanceToPlayer() > attackRange) {
            transform.position = Vector3.MoveTowards(transform.position, playerController.transform.position, moveSpeed * Time.deltaTime);
        }
    }

    protected void Stop()
    {
        if (attackRange >= CalculateDistanceToPlayer()) {
            transform.position = transform.position;
        }
    }

    virtual public void AttackTarget()
    {
        if (playerController) {
            target.GetComponent<Health>().TakeDamage(attackDamage);
        }
        else {
            animator.SetBool(isAttackingHash, false);
        }
    }

    protected float CalculateDistanceToPlayer()
    {
        float distance = Vector3.Distance(transform.position, playerController.transform.position);
        return distance;
    }

    private void OnDestroy()
    {
        scoreKeeper.AddScore(killScore);
    }

}
