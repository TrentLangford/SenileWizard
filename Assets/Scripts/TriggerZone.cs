using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public GameObject Unhide;
    private void OnTriggerEnter(Collider other)
    {
        Unhide.SetActive(true);
    }
}
