using System;
using System.Collections;
using System.Collections.Generic;
using Services;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlateController : MonoBehaviour, IDropHandler
{
    [field: SerializeField] public RectTransform MeatTransform { get; private set; }
    [SerializeField] private PlateView _plateView;
    private PlateModel _plateModel;
    private MealStatus _currentMealStatus;

    public void Initialize(PlateModel plateModel)
    {
        _plateModel = plateModel;
        _plateModel.IsAvailable = false;
        _plateView.ChangeMealState(false);
        _currentMealStatus = MealStatus.Uncompleted;
    }
    

    public void OnDrop(PointerEventData eventData)
    {
        var ingredient = ServiceLocator.Instance.GetSingle<IDragBufferService>().GetElement();
        var meatController = ingredient.GetComponent<MeatController>();
        if (meatController != null)
        {
            _currentMealStatus = MealStatus.Completed;
            _plateView.ChangeMealState(true);
            EventStreams.Game.Publish(new ReleaseMeatRequest(meatController));
            
        }
        Debug.Log("Бургер готов");
    }
}