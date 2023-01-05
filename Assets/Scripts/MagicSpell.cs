using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSpell : MonoBehaviour
{
    // public GameObject spelltoCast;
    public float time = 3f;
    [SerializeField] LayerMask walls;
    [SerializeField] Transform wallsCheck;

    void Awake()
    {
        Destroy(gameObject, time);
    }
    
    void Update()
    {
        //Debug.Log("Colliding with Wall?: " + IsCollidingWithWall());
        
    }
    private void OnCollisionEnter(Collision collision) // used for hit-bounce collision
    {
        if(!collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy")) // if not player or enemy, aka, any scene item, destroy
        {
            Destroy(gameObject);
        }

        /*if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.TryGetComponent<EnemyFollow>(out EnemyFollow enemy); //get enemy object
            enemy.Damaged(1); //magic spell deals 3 damage
        }*/
    }

    private void OnTriggerEnter(Collider other) // used for pass-through collisions, needs 1(not 2) Is Trigger to true
    {                                             // currently used to hit enemies and not send them flying
                                               // problem-> ball is hitting player when spawning
        
        if(other.tag == "Enemy")
        {
            Debug.Log("hit enemy 1");
            other.gameObject.TryGetComponent<EnemyFollow>(out EnemyFollow enemy); //get enemy object
            enemy.Damaged(3); //magic deals 3 damage
            Destroy(gameObject);

        }
        if(other.tag == "Enemy2")
        {
            Debug.Log("hit enemy 2");
            other.gameObject.TryGetComponent<Enemy2Follow>(out Enemy2Follow enemy); //get enemy object
            enemy.Damaged(3); //magic deals 3 damage
            Destroy(gameObject);

        }
        if(other.tag == "Boss")
        {
            other.gameObject.TryGetComponent<BossFollow>(out BossFollow enemy); //get enemy object
            enemy.Damaged(3); //magic deals 3 damage
            Destroy(gameObject);

        }
        if(other.tag == "BannerTarget")
        {
            Debug.Log("hitBanner");
            other.gameObject.TryGetComponent<BannerTarget>(out BannerTarget bannerTarget); //get enemy object
            bannerTarget.getHit();

        }
    }
    bool IsCollidingWithWall() //unused?
    {
        return Physics.CheckSphere(wallsCheck.position, .1f, walls);
    }
}
