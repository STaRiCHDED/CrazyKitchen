using System;
using UnityEngine;

public class PanView : MonoBehaviour
{
    public event Action MeatCooked;
    [field: SerializeField] public RectTransform MeatTransform { get; private set; }

    private MeatView _meatView;
    private float _currentTime;

    public void Initialize(MeatView meatView)
    {
        _meatView = meatView;
        _meatView.SetPosition(MeatTransform);
    }
    
    public void Cook(float cookingTime)
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= cookingTime)
        {
            _currentTime = 0;
            MeatCooked?.Invoke();
            _meatView.ChangeMeatView();
        }
    }
    
}