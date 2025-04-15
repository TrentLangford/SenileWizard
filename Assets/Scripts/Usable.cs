using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Usable : MonoBehaviour
{
    // Forces use/reset event to fire
    public bool Used {  get; private set; }
    public UnityEvent OnUse;
    public UnityEvent OnReset;
    public void Use()
    {
        Debug.Log("a");
        Used = true;
        OnUse.Invoke();
    }

    // Reset is a reserved func... bruh
    public void Res()
    {
        Used = false;
        OnReset.Invoke();
    }
}
