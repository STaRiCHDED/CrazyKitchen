using System;
using UnityEngine;

public class PanView : MonoBehaviour
{
    public event Action MeatCooked;
    [field: SerializeField] public RectTransform MeatTransform { get; private set; }

    private Meat _meat;
    private Color _startMeatColor;
    private float _currentTime;

    public void Initialize(Meat meat)
    {
        _meat = meat;
        _meat.SetPosition(MeatTransform);
        _startMeatColor = _meat.MeatImage.color;
    }
    
    public void Cook(float cookingTime)
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= cookingTime)
        {
            _meat.IsCooked = true;
            _currentTime = 0;
            MeatCooked?.Invoke();
            return;
        }

        _meat.MeatImage.color = Color.Lerp(_startMeatColor, Color.black, _currentTime / cookingTime);
    }
    
}