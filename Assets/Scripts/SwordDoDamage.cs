using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDoDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) // used for pass-through collisions, needs 1(not 2) Is Trigger to true
    {
        if(other.tag == "Enemy")
        {
            //Destroy(gameObject);
            //other.gameObject.TryGetComponent<BasicEnemy>(out BasicEnemy enemy);
            other.gameObject.TryGetComponent<EnemyFollow>(out EnemyFollow enemy); //get enemy object
            enemy.Damaged(1); //sword deals 1 damage

        }
    }
}
