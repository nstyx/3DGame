using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressure23 : MonoBehaviour
{
    public bool plateActivated;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            float distance = Vector3.Distance(transform.position, other.transform.position);

            if(distance < 0.6f)
            {
                plateActivated = true;

                MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();

                if(meshRenderer != null)
                {
                    meshRenderer.material.color = Color.green;
                    //StartCoroutine(ChangeColor());
                }
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {

            MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();

            if(meshRenderer != null)
            {
                meshRenderer.material.color = Color.red;
                //StartCoroutine(ChangeColor());
            }
        }
    }

    IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(3.0f);

        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();

        if(meshRenderer != null)
        {
            meshRenderer.material.color = Color.red;
        }
        
    }

}
