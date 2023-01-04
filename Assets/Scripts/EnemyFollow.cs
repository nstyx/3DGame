using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] float currentHealth, maxHealth = 3f;
    public NavMeshAgent enemy;
    public Transform player;

    public float sightRange = 3f;
    public float attackRange = 0.5f;
    public bool playerInSightRange;
    public bool playerInAttackRange;

    public LayerMask whatIsPlayer;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        anim.SetBool("isEnemy1Attacking", false);
        anim.SetBool("isEnemy1Walking", false);
    }

    // Update is called once per frame
    void Update()
    {
        //is player in attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if(playerInSightRange) FollowPlayer();
        if(!playerInSightRange) StopMoving();
        if(playerInSightRange && playerInAttackRange) AttackPlayer();
        if(!playerInAttackRange) anim.SetBool("isEnemy1Attacking", false);
        //if(!playerInSightRange) anim.SetBool("isEnemy1Walking", false);
        if(enemy.velocity.sqrMagnitude < 0.1) anim.SetBool("isEnemy1Walking", false);
    }
    private void StopMoving()
    {
        enemy.velocity = new Vector3(0,0,0);
    }

    private void FollowPlayer()
    {
        anim.SetBool("isEnemy1Walking", true);
        enemy.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        // look at player x pos, player z pos, but keep enemy Y pos so enemy doesnt look upwards
        Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(targetPosition);
        anim.SetBool("isEnemy1Attacking", true);
        enemy.SetDestination(transform.position);
    }

    public void Damaged(float dmgAmount)
    {
        Debug.Log("here");
        currentHealth -= dmgAmount;

        if(currentHealth < 1)
        {
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
}
