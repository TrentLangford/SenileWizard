using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballInteract : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fire"))
        {
            other.GetComponent<Usable>().Use();
            
        }

        if (!other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
