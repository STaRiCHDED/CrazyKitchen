using System;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class MeatModel
    {
        [field: SerializeField]
        public bool IsCooked { get; set; }

        public MeatModel(bool isCooked)
        {
            IsCooked = isCooked;
        }
    }
}