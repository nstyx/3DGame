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

        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.TryGetComponent<BasicEnemy>(out BasicEnemy enemy); //get enemy object
            enemy.Damaged(1); //magic spell deals 1 damage
        }
    }

    private void OnTriggerEnter(Collider other) // used for pass-through collisions, needs 1(not 2) Is Trigger to true
    {                                             // currently disabled because magic ball sphere collider Is Trigger is false
        Debug.Log("hit something");               // problem-> ball is hitting player when spawning
        if(other.tag == "Enemy")
        {
            //Destroy(gameObject);
            Debug.Log("hit enemy");

        }
    }
    bool IsCollidingWithWall() //unused?
    {
        return Physics.CheckSphere(wallsCheck.position, .1f, walls);
    }
}
