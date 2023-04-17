using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PanController : MonoBehaviour, IDropHandler
{
    [SerializeField] private PanView _panView;
    
    private PanModel _panModel;
    private MeatController _meatController;
    
    public void Initialize(PanModel panModel, MeatController meatController)
    {
        _panModel = panModel;
        _meatController = meatController;
        _panView.Initialize(_meatController.MeatView);
        _panModel.IsAvailable = false;
        
        _panView.MeatCooked += OnMeetCooked;
    }

    private void OnMeetCooked()
    {
        _meatController.ChangeMeatState();
    }

    private void Update()
    {
        if ( _panModel==null || _panModel.IsAvailable)
        {
            return;
        }
        
        _panView.Cook(_panModel.CookingTime);
    }


    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Сковородкин");
    }
}