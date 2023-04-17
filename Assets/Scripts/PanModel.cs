using System;
using UnityEngine;

[Serializable]
public class PanModel
{
    [field: SerializeField] public bool IsAvailable { get; set; }
    [field: SerializeField] public float CookingTime { get; private set; }

    public PanModel(bool isAvailable, float cookingTime)
    {
        IsAvailable = isAvailable;
        CookingTime = cookingTime;
    }
}