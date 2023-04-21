using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class PlateView : MonoBehaviour
    {
        public Image PlateImage => _plateImage;
        public Vector3 StartPosition { get; private set; }
        [field: SerializeField]
        public CanvasGroup CanvasGroup { get; private set; }
        
        [SerializeField]
        private Image _plateImage;
    
        [SerializeField]
        private Sprite _uncompletedMeal;
    
        [SerializeField]
        private Sprite _completedMeal;

        public void ChangeMealState(bool isReady)
        {
            _plateImage.sprite = isReady ? _completedMeal : _uncompletedMeal;
        }

        public void SetPosition(RectTransform rootTransform)
        {
            StartPosition = rootTransform.position;
        }
    }
}
