using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderLock : MonoBehaviour
{
    public List<Usable> Elements;
    public Objective CompletionObjective;
    private List<bool> used;

    public Color Ticked;
    public Color Unticked;

    void Start()
    {
        used = new List<bool>(Elements.Count);
        for (int i = 0; i < Elements.Count; i++)
        {
            used.Add(false);
        }
    }

    public void Verify()
    {
        for (int i = 0; i < Elements.Count; i++)
        {
            used[i] = Elements[i].Used;
            // nice long chain
            if (used[i]) Elements[i].gameObject.GetComponent<MeshRenderer>().material.color = Ticked;
        }

        // This is a very odd way to verify a sequence of true/false
        // but it allows any sequence of continuous true followed by continuous false
        int correct = 0;
        for (int i = 0; i < Elements.Count; i++)
        {
            if (i != 0 && used[i] && !used[i - 1])
            {
                Untick();
                return;
            }
            if (used[i]) correct++;
        }

        Debug.Log($"{correct} correct");
        if (correct == Elements.Count) CompletionObjective.Complete();
    }

    void Untick()
    {
        for (int i = 0; i < Elements.Count; i++)
        {
            // very long chain
            Elements[i].gameObject.GetComponent<MeshRenderer>().material.color = Unticked;
            Elements[i].Res();
            used[i] = false;
        }
    }
}
