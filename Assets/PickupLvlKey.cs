using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLvlKey : MonoBehaviour
{
    // Start is called before the first frame update
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
            //open door to lvl2
            GameManager.foundKeyLvl2 = 1;
            Debug.Log("keylvl2: " + GameManager.foundKeyLvl2);
            Destroy(gameObject);
        }
    }
}
