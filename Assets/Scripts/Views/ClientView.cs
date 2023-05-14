using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientView : MonoBehaviour
{
    public event Action ActionIsOver;
    
    [SerializeField] 
    private OrderView _orderView;

    [SerializeField]
    private Image _currentStateView;

    [SerializeField]
    private Sprite _initialMoodSprite;

    [SerializeField]
    private Sprite _pleasedMoodSprite;
    
    [SerializeField]
    private Sprite _angryMoodSprite;

    private float _currentTime;
    
    [SerializeField]
    private Vector3 _startPosition;
    
    [SerializeField]
    private Vector3 _kitchenPosition;

    [SerializeField] 
    private Vector3 _endPosition;

    private void Awake()
    {
        _currentStateView.sprite = _initialMoodSprite;
    }
    public void Initialize(OrderView orderView,Action OnOrderDelivered)
    {
        _orderView = orderView;
        _orderView.OrderDelivered += OnOrderDelivered;
    }
    
    public void Wait(float waitingTime)
    {
        _currentTime += Time.deltaTime;
        // Debug.Log($"Timer {(int)_currentTime} EndTime {waitingTime}");
        if (_currentTime >= waitingTime)
        {
            _currentTime = 0;
            _orderView.UpdateOrderState(false);
            ChangeMoodState(false);
            ActionIsOver?.Invoke();
        }
    }

    public void ChangeMoodState(bool flag)
    {
        _currentStateView.sprite = flag ? _pleasedMoodSprite : _angryMoodSprite;
    }

    public void SetPosition(RectTransform rectTransform)
    {
        transform.SetParent(rectTransform);
        transform.position = _startPosition;
    }

    public IEnumerator MoveToKitchen()
    {
        float timeElapsed = 0f;
        while (timeElapsed < 3f)
        {
            timeElapsed += Time.deltaTime;
            float t = timeElapsed / 3f;
            transform.position = Vector3.Lerp(_startPosition,_kitchenPosition,t);
            yield return null;
        }
        ActionIsOver?.Invoke();
        Debug.Log("Я пришёл");
        _orderView.UpdateOrderState(true);
    }
    public IEnumerator LeaveKitchen()
    {
        float timeElapsed = 0f;
        while (timeElapsed < 5f)
        {
            timeElapsed += Time.deltaTime;
            float t = timeElapsed / 5f;
            transform.position = Vector3.Lerp(_kitchenPosition,_endPosition,t);
            yield return null;
        }
        ActionIsOver?.Invoke();
        Debug.Log("Я ушёл");
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        _orderView.OrderDelivered = null;
    }
}
