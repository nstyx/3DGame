using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLvlKey : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string fromLevel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(fromLevel == "1")
            {
                //open door to lvl2
                GameManager.foundKeyLvl2 = 1;
                Destroy(gameObject);
            }
            if(fromLevel == "2")
            {
                //open door to lvl3
                GameManager.foundKeyLvl3 = 1;
                Destroy(gameObject);
            }
            if(fromLevel == "3")
            {
                //open boss door
                GameManager.foundKeyBoss = 1;
                Destroy(gameObject);
            }
        }
    }
}
