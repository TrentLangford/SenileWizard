using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public GameObject Player;
    public float Speed = 10f;
    Vector3 dir;
    Rigidbody body;
    void Awake()
    {
        Player = GameObject.Find("Player");
        body = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        dir = (Player.transform.position - transform.position).normalized;
        body.AddForce(transform.position + dir * Speed);
        transform.localRotation = Quaternion.LookRotation(dir, transform.up);
    }
}
