using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPickup : MonoBehaviour
{
    // TO-DO add bool that sets current weapon, to prevent shoot animation in sword mode, and melee animation in bow mode
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
            FindObjectOfType<GameManager>().addBook();
            Destroy(gameObject);

        }
    }
}
