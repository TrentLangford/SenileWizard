using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionIngredient : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Pot"))
        {
            collision.gameObject.GetComponent<PotionMaking>().AddIngredient();
            PlayerGrab grabScript = GameObject.Find("Player").GetComponent<PlayerGrab>();
            grabScript.EndGrab(); // Ensures that the player lets go of the object before it gets destroyed
            Destroy(this.gameObject);
        }
    }
}
