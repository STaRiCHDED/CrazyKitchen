﻿namespace Views
{
    public class MeatView : CookableItemView
    {
    }
}


// public class MeatView : CookableItemView
// {
//     [SerializeField]
//     private Image _currentMeatStateView;
//     
//     [SerializeField] 
//     private Sprite _rawMeat;
//     
//     [SerializeField] 
//     private Sprite _readyMeat;
//
//     public Vector3 PanPosition { get; private set; }
//
//     [field: SerializeField]
//     public CanvasGroup Group { get; private set; }
//
//     private void Awake()
//     {
//         _currentMeatStateView.sprite = _rawMeat;
//     }
//
//     public void ChangeMeatView()
//     {
//         _currentMeatStateView.sprite = _readyMeat;
//     }
//     
//     public void SetPosition(RectTransform parentTransformPosition)
//     {
//         transform.SetParent(parentTransformPosition);
//         transform.position = parentTransformPosition.position;
//         PanPosition = parentTransformPosition.position;
//     }
//     
// }