using System;
using UnityEngine;

namespace B.ConfigModels
{
    [Serializable]
    public class ConfigUtensilModel
    {
        public string Name => _name;
        
        public Sprite View => _view;
        
        public bool IsAvailable => _isAvailable;
        
        [SerializeField]
        private string _name;
        
        [SerializeField]
        private Sprite _view;
        
        [SerializeField]
        private bool _isAvailable;
    }
}