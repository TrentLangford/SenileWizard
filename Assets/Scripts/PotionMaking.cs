using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionMaking : MonoBehaviour
{
    public int Ingredients;
    public int MaxIngredients;
    public Objective CompletionObjective;
    public void AddIngredient()
    {
        Ingredients++;
        if (Ingredients >= MaxIngredients) CompletionObjective.Complete();
    }
}
