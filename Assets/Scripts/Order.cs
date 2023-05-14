﻿using Controllers;
using Services;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
// TODO: Перейти на класс OrderView, этот класс удалить
public class Order : MonoBehaviour, IDropHandler
{
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
        }

    }
    
}