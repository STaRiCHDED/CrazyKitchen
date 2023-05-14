using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using Services;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OrderView : MonoBehaviour, IDropHandler
{
    public Action OrderDelivered;
    [SerializeField]
    private Image _orderView;
    
    public void OnDrop(PointerEventData eventData)
    {
        var ingredient = ServiceLocator.Instance.GetSingle<IDragBufferService>().GetElement();
        var plateController = ingredient.GetComponent<PlateController>();

        if (plateController != null && plateController.CompareMeals(_orderView.sprite))
        {
            gameObject.SetActive(false);
            plateController.transform.position = plateController.StartPosition;
            plateController.ResetMeal();
            OrderDelivered?.Invoke();
        }

    }
    public void UpdateOrderState(bool flag)
    {
        Debug.Log($"UpdateOrderState");
        gameObject.SetActive(flag);
    }
}
