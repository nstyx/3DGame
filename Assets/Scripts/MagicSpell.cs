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
    private void OnCollisionEnter(Collision collision) //current collision for magicball, hit everything except player
    {
        if(!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) //apply damage to enemies or whatever
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);

        }
    }
    bool IsCollidingWithWall() //unused?
    {
        return Physics.CheckSphere(wallsCheck.position, .1f, walls);
    }
}
