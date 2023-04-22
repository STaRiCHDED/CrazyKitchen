using UnityEngine;
using UnityEngine.UI;

namespace B.Views
{
    public class UtensilView : MonoBehaviour
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