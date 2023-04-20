using System;
using UnityEngine;
using UnityEngine.UI;

public class PlateView : MonoBehaviour
{
    [SerializeField] private Image _plateImage;
    [SerializeField] private Sprite _uncompletedMeal;
    [SerializeField] private Sprite _completedMeal;
    
    public void ChangeMealState(bool isReady)
    {
        _plateImage.sprite = isReady ? _completedMeal : _uncompletedMeal;
        
    }
}