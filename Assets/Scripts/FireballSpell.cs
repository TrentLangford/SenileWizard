using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpell : MonoBehaviour
{
    public GameObject fireballPrefab;
    public float fireballSpeed;
    public PlayerLook lookscript;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject FIREBALL = Instantiate(fireballPrefab, lookscript.CameraTransform.position, Quaternion.identity);
            FIREBALL.GetComponent<Rigidbody>().AddForce(lookscript.CameraTransform.forward * fireballSpeed);
        }
    }
}
