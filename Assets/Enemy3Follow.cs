using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy3Follow : MonoBehaviour
{
    [SerializeField] float currentHealth, maxHealth = 1f;
    public NavMeshAgent enemy;
    public Transform player;

    public float sightRange = 7f;
    public float attackRange = 0.4f;
    public bool playerInSightRange;
    public bool playerInAttackRange;

    public LayerMask whatIsPlayer;
    public Animator anim;
    public BoxCollider swordCollider;

    private bool attacked = false;
    private bool enemyDead;
    private float attackDelay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        anim.SetBool("isEnemy3Attacking", false);
        anim.SetBool("isEnemy3Walking", false);
        swordCollider.enabled = false;
        enemyDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!enemyDead)
        {
            //is player in attack range
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            if(playerInSightRange) FollowPlayer();
            if(!playerInSightRange) StopMoving();
            if(playerInSightRange && playerInAttackRange) AttackPlayer();
            if(!playerInAttackRange) anim.SetBool("isEnemy3Attacking", false);
            //if(!playerInSightRange) anim.SetBool("isEnemy1Walking", false);
            if(enemy.velocity.sqrMagnitude < 0.1) anim.SetBool("isEnemy3Walking", false);
        }
    }
    private void StopMoving()
    {
        enemy.velocity = new Vector3(0,0,0);
    }

    private void FollowPlayer()
    {
        anim.SetBool("isEnemy3Walking", true);
        enemy.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        // look at player x pos, player z pos, but keep enemy Y pos so enemy doesnt look upwards
        Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(targetPosition);
        anim.SetBool("isEnemy3Attacking", true);
        enemy.SetDestination(transform.position);

        if(!attacked)
        {
            attacked = true;
            Invoke(nameof(AttackReset), attackDelay);
        }
    }

    private void AttackReset()
    {
        attacked = false;
    }

    public void Damaged(float dmgAmount)
    {
        currentHealth -= dmgAmount;

        if(currentHealth < 1)
        {
            enemyDead = true;
            anim.SetBool("enemy3Dead", true);
            Destroy(gameObject);
        }

        StopMoving();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    public void AttackStart()
    {
        swordCollider.enabled = true;
    }
    public void AttackFinished()
    {
        swordCollider.enabled = false;
    }
}
