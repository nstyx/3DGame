using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour //only exists in this scene, can use for BossDoor
{

    public GameObject keyDoorOpen;
    public GameObject keyDoorClosed;
    public GameObject lvl2DoorOpen;
    public GameObject lvl2DoorClosed;

    public GameObject bossDoorOpen;
    public GameObject bossDoorClosed;
    private bool plateActivated;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "MovingBox")
        {
            float distance = Vector3.Distance(transform.position, other.transform.position);

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
        keyDoorClosed.SetActive(true);
        keyDoorOpen.SetActive(false);
        plateActivated = false;

        bossDoorClosed.SetActive(true);
        bossDoorOpen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!plateActivated)
        {
            keyDoorClosed.SetActive(true);
            keyDoorOpen.SetActive(false);
        }
        else
        {
            keyDoorClosed.SetActive(false);
            keyDoorOpen.SetActive(true);
        }

        if(GameManager.foundKeyLvl2 == 1)
        {
            lvl2DoorClosed.SetActive(false);
            lvl2DoorOpen.SetActive(true);
        }
        if(GameManager.foundKeyBoss == 1)
        {
            bossDoorClosed.SetActive(false);
            bossDoorOpen.SetActive(true);
        }
        
    }
}
