using System;
using B.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace B.Views
{
    public class CookingUtensilView : MonoBehaviour
    {
        [SerializeField]
        private Image _currentImage;
        
        [SerializeField]
        private Sprite _view;
        
        private void Awake()
        {
            _currentImage.sprite = _view;
        }
    }
}