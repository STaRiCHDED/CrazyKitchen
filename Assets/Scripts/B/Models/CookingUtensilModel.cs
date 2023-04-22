using System;
using B.Interfaces;
using UnityEngine;

namespace B.Models
{
    [Serializable]
    public class CookingUtensilModel : IUtensil
    {
        public string Name { get; }
        public bool IsAvailable { get; set; }
        public float CookingTime { get; }

        public CookingUtensilModel(string name, bool isAvailable, float cookingTime)
        {
            Name = name;
            IsAvailable = isAvailable;
            CookingTime = cookingTime;
        }
    }
}