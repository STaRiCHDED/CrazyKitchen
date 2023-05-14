using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderController : MonoBehaviour
{
    public OrderView OrderView => _orderView;

    [SerializeField] private OrderView _orderView;

    //[SerializeField] private OrderModel _OrderModel;

    public void ChangeOrderState(bool isReady)
    {
        _orderView.UpdateOrderState(isReady);
    }
}