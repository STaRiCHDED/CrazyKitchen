using System;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class PlateView : MonoBehaviour
    {
        public Image PlateImage => _plateImage;
       
        [field: SerializeField]
        public CanvasGroup CanvasGroup { get; private set; }
        
        [SerializeField]
        private Image _plateImage;

        [SerializeField]
        private Sprite _emptyMeal;
        
        [SerializeField]
        private Sprite _uncompletedMeal;
    
        [SerializeField]
        private Sprite _completedMeal;

        private void Awake()
        {
            _plateImage.sprite = _emptyMeal;
        }

        public void ChangeMealState(bool isReady)
        {
            _plateImage.sprite = isReady ? _completedMeal : _uncompletedMeal;
        }

        public void ResetView()
        {
            _plateImage.sprite = _emptyMeal;
        }
    }
}
