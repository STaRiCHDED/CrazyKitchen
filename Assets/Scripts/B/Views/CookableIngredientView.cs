using System;
using B.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace B.Views
{
    public class CookableIngredientView : MonoBehaviour
    {
        [field: SerializeField]
        public CanvasGroup CanvasGroup { get; private set; }

        [SerializeField]
        private Image _currentImage;
        
        public void DisplayView(Sprite currentStateSprite)
        {
            _currentImage.sprite = currentStateSprite;
        }
    }
}