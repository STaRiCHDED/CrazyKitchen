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
    public MealStatus CurrentMealStatus { get; private set; }

    private void Awake()
    {
        CurrentMealStatus = MealStatus.Empty;
    }

    public void Initialize(PlateModel plateModel)
    {
        _plateModel = plateModel;
        _plateModel.IsAvailable = false;
        _plateView.ChangeMealState(false);
        CurrentMealStatus = MealStatus.Uncompleted;
    }
    

    public void OnDrop(PointerEventData eventData)
    {
        if (CurrentMealStatus is MealStatus.Completed or MealStatus.Empty)
        {
            return;
        }
        var ingredient = ServiceLocator.Instance.GetSingle<IDragBufferService>().GetElement();
        var meatController = ingredient.GetComponent<MeatController>();
        if (meatController != null)
        {
            CurrentMealStatus = MealStatus.Completed;
            _plateView.ChangeMealState(true);
            EventStreams.Game.Publish(new ReleaseMeatRequest(meatController));
            meatController.ChangeMeatState(false);
            
        }
        Debug.Log("Бургер готов");
    }
}