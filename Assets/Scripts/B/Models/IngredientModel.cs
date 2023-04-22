using B.Interfaces;
using UnityEngine;

namespace B.Models
{
   
    public class IngredientModel : IIngredient
    {
        public string Name { get; }
        public float Price { get; }
        public Sprite View { get; }

        public IngredientModel(string name, float price, Sprite view)
        {
            Name = name;
            Price = price;
            View = view;
        }
    }
}