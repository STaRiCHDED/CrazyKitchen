using System;
using B.Interfaces;
using UnityEngine;

namespace B.Models
{
    [Serializable]
    public class CookableIngredientModel : IIngredient
    {
        public string Name { get; }
        public float Price { get; }
        public Sprite Uncompleted { get; }
        public Sprite Completed { get; }
        public bool IsCooked { get; set; }

        public CookableIngredientModel(string name, float price, Sprite uncompleted, Sprite completed, bool isCooked)
        {
            Name = name;
            Price = price;
            Uncompleted = uncompleted;
            Completed = completed;
            IsCooked = isCooked;
        }
    }
}