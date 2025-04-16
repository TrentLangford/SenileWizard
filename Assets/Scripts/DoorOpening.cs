using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Door"))
        {
            collision.gameObject.GetComponentInParent<Objective>().Complete();
            Destroy(this.gameObject);
        }
    }
}
