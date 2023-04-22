using UnityEngine;

namespace B.Interfaces
{
    public interface IUtensil
    {
        public string Name { get; }
        public bool IsAvailable { get; }
    }
}