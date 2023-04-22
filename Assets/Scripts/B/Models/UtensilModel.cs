using B.Interfaces;
using UnityEngine;

namespace B.Models
{
    public class UtensilModel : IUtensil
    {
        public string Name { get; }
        public bool IsAvailable { get; }

        public UtensilModel(string name, bool isAvailable)
        {
            Name = name;
            IsAvailable = isAvailable;
        }
    }
}