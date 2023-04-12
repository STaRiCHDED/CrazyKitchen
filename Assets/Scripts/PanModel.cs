using System;
using UnityEditor;
using UnityEngine;

[Serializable]
public class PanModel
{
    public float CookingTime => _cookingTime;

    public bool IsEmpty
    {
        get => _isEmpty;
        set => _isEmpty = value;
    }

    [SerializeField] private float _cookingTime;
    [SerializeField] private bool _isEmpty;

    public PanModel(float cookingTime)
    {
        _cookingTime = cookingTime;
        _isEmpty = false;
    }
}