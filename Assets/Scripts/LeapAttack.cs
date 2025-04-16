using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeapAttack : MonoBehaviour
{
    Rigidbody body;
    GameObject player;
    public float LeapForce;
    private void Awake()
    {
        Invoke("Leap", 0.1f);
    }

    void Leap()
    {
        body = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        Vector3 dir = (player.transform.position - transform.position).normalized;
        Debug.DrawRay(transform.position, dir * 10f, Color.red, 10f);
        body.AddForce(dir * LeapForce);
        transform.localRotation = Quaternion.LookRotation(dir);
    }
}
