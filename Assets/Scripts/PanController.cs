using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PanController : MonoBehaviour, IDropHandler
{
    [SerializeField] private PanView _panView;
    
    private PanModel _panModel;
    
    public void Initialize(PanModel panModel, Meat meat)
    {
        _panModel = panModel;
        _panView.Initialize(meat);
        _panModel.IsAvailable = false;
        
        _panView.MeatCooked += OnMeetCooked;
    }

    private void OnMeetCooked()
    {
        _panModel.IsAvailable = true;
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