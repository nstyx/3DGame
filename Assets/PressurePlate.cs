using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    public GameObject lvl2DoorOpen;
    public GameObject lvl2DoorClosed;
    private bool plateActivated;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "MovingBox")
        {
            float distance = Vector3.Distance(transform.position, other.transform.position);
            Debug.Log("Distance: " + distance);

            if(distance < 0.6f)
            {
                plateActivated = true;

                MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();

                if(meshRenderer != null)
                {
                    meshRenderer.material.color = Color.green;
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        lvl2DoorClosed.SetActive(true);
        lvl2DoorOpen.SetActive(false);
        plateActivated = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!plateActivated)
        {
            lvl2DoorClosed.SetActive(true);
            lvl2DoorOpen.SetActive(false);
        }
        else
        {
            lvl2DoorClosed.SetActive(false);
            lvl2DoorOpen.SetActive(true);
        }
        
    }
}
