using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletionLock : MonoBehaviour
{
    public List<Usable> Elements;
    public Objective CompletionObjective;

    public Color Ticked;

    public void Verify()
    {
        // no need to check order just verify completion
        int correct = 0;
        for (int i = 0; i < Elements.Count; i++)
        {
            if (Elements[i].Used)
            {
                Elements[i].gameObject.GetComponent<MeshRenderer>().material.color = Ticked;
                correct++;
            }
        }

        Debug.Log($"{correct} correct");
        if (correct == Elements.Count) CompletionObjective.Complete();
    }
}
