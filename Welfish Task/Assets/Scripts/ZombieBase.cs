using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class ZombieBase : MonoBehaviour
{
    protected Animator animator;
    protected int isAttackingHash;
    protected NavMeshAgent enemy;
    protected PlayerController playerController;
    public AudioClip hitSfx;
    public GameObject target;
    protected ScoreKeeper scoreKeeper;
    public int attackDamage = 15;
    public int killScore = 50;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        animator = GetComponent<Animator>();
        enemy = GetComponent<NavMeshAgent>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

        isAttackingHash = Animator.StringToHash("isAttacking");
    }

    // Update is called once per frame
    virtual public void Update()
    {
        if (playerController) {
            enemy.SetDestination(playerController.transform.position);
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

    private void OnDestroy()
    {
        scoreKeeper.AddScore(killScore);
    }

}
