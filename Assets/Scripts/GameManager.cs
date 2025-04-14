using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Objective> Objectives;
    public Objective CompletionObjective;

    public void Verify()
    {
        foreach (Objective obj in Objectives)
        {
            if (!obj.isComplete) return;
        }

        CompletionObjective.Complete();
    }
}
