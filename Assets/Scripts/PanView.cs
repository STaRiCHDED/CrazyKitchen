using System;
using UnityEngine;

public class PanView : MonoBehaviour
{
    [SerializeField] private Sprite _meatSprite;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void CookMeat(float cookingTime)
    {
        _renderer.gameObject.SetActive(true);
        var color = _renderer.color;
        _renderer.color = Color.Lerp(color, Color.black, cookingTime);
    }
}