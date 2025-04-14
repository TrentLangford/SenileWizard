using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    [Header("Objective Completion Settings")]
    public GameObject SpawningPrefab;
    public Transform SpawningPosition;
    public bool SpawnObject;
    public bool UnhideChild;
    public bool HideSelf;

    [Header("Objective Metadata")]
    public string Message;
    public bool isComplete = false;
    public void Complete()
    {
        isComplete = true;
        if (SpawnObject)
        {
            GameObject spawned = Instantiate(SpawningPrefab);
            spawned.transform.position = SpawningPosition.position;
        }

        if (UnhideChild)
        {
            GameObject child = this.transform.GetChild(0).gameObject;
            child.SetActive(true);
        }

        if (HideSelf)
        {
            this.gameObject.SetActive(false);
        }
    }
}
