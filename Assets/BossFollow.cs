using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class BossFollow : MonoBehaviour
{
    [SerializeField] float currentHealth, maxHealth = 50f;
    [SerializeField] private CanvasGroup image;
    public NavMeshAgent enemy;
    public Transform player;

    public float sightRange = 7f;
    public float attackRange = 2f;
    public bool playerInSightRange;
    public bool playerInAttackRange;

    public LayerMask whatIsPlayer;
    public Animator anim;
    public CapsuleCollider swordCollider;

    private bool isAttacking = false;
    private bool enemyDead;
    private float attackDelay = 2f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        anim.SetBool("isBossAttacking", false);
        anim.SetBool("isBossWalking", false);
        anim.SetBool("damage", false);
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
            if(!playerInAttackRange) anim.SetBool("isBossAttacking", false);
            //if(!playerInSightRange) anim.SetBool("isEnemy1Walking", false);
            if(enemy.velocity.sqrMagnitude < 0.1) anim.SetBool("isBossWalking", false);
        }
    }
    private void StopMoving()
    {
        enemy.velocity = new Vector3(0,0,0);
    }

    private void FollowPlayer()
    {
        anim.SetBool("isBossWalking", true);
        enemy.SetDestination(player.position);
    }
    private void AttackPlayer() //attack takes 2 seconds
    {
        // look at player x pos, player z pos, but keep enemy Y pos so enemy doesnt look upwards
        Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(targetPosition);
        anim.SetBool("isBossAttacking", true);
        enemy.SetDestination(transform.position);

        if(!isAttacking)
        {
            isAttacking = true;
            Invoke(nameof(AttackReset), attackDelay);
        }
    }

    private void AttackReset()
    {
        isAttacking = false;
        Debug.Log("4 seconds passed");
    }

    public void Damaged(float dmgAmount)
    {
        currentHealth -= dmgAmount;
        if(currentHealth < 1)
        {
            StopMoving();
            enemyDead = true;
            anim.SetBool("BossDead", true);
            StartCoroutine(BossDeadDelay());
            //Destroy(gameObject);
        }
        anim.SetBool("damage", true);
        StartCoroutine(DamageDelayAnim());

        StopMoving();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.white;
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

    private IEnumerator BossDeadDelay()
    {
        StartCoroutine(FadeIn());
        yield return new WaitForSeconds(3.5f);
        Time.timeScale = 0f;
        Debug.Log("Victory");
        //VictoryScreen
        Time.timeScale = 1f;
        SceneManager.LoadScene("VictoryScreen");
    }
    private IEnumerator DamageDelayAnim()
    {
        Debug.Log("here3");
        yield return new WaitForSeconds(0.6f);
        anim.SetBool("damage", false);
    }

    IEnumerator FadeIn()
    {
        // Fade in over 2 seconds
        float elapsedTime = 0f;
        float fadeTime = 4f;

        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            image.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeTime);
            yield return null;
        }
    }
}

