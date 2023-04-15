using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanController : MonoBehaviour, IDropHandler
{
    [field: SerializeField] public RectTransform MeatTransform { get; private set; }

    [field: SerializeField] public bool IsAvailable { get; private set; }

    [SerializeField] private float _cookingTime;

    private Meat _meat;
    private float _currentTime;
    private Color _startMeatColor;

    public void Initialize(Meat meat)
    {
        _meat = meat;
        _startMeatColor = _meat.MeatImage.color;
    }

    public void SetPanAvailable(bool isAvailable)
    {
        IsAvailable = isAvailable;
    }

    private void Update()
    {
        if (_meat != null)
        {
            Cook();
        }
    }

    private void Cook()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= _cookingTime)
        {
            // todo сеттить IsAvailable в true, оповещать о приготовлении мяса
            return;
        }

        _meat.MeatImage.color = Color.Lerp(_startMeatColor, Color.black, _currentTime / _cookingTime);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Сковородкин");
    }
}