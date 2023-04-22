using System;
using UnityEngine;

namespace B.ConfigModels
{
    [Serializable]
    public class ConfigCookableUtensilModel
    {
        public string Name => _name;
        
        public Sprite View => _view;
        
        public bool IsAvailable => _isAvailable;
        
        public float CookingTime => _cookingTime;
        
        [SerializeField]
        private string _name;

        [SerializeField]
        private Sprite _view;
        
        [SerializeField]
        private bool _isAvailable;
        
        [SerializeField]
        private float _cookingTime;
    }
}