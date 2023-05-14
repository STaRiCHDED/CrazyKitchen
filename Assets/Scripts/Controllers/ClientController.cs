using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientController : MonoBehaviour
{
    [SerializeField] 
    private ClientView _clientView;

    [SerializeField] 
    private ClientModel _clientModel;
    [SerializeField] 
    private OrderController _orderController;

    private bool _isCurrentCoroutineFinished;

    // public void Initialize(ClientModel clientModel, OrderController orderController,RectTransform transform)
    // {
    //     _clientModel = clientModel;
    //     _orderController = orderController;
    //     _clientView.Initialize(_orderController.OrderView,OnOrderDelivered);
    //     _clientView.SetPosition(transform);
    //     _clientView.ActionIsOver += OnCoroutineEnded;
    // }
    public void Initialize(RectTransform transform)
    {
        _clientView.Initialize(_orderController.OrderView,OnOrderDelivered);
        _clientView.SetPosition(transform);
        _clientView.ActionIsOver += OnCoroutineEnded;
        _isCurrentCoroutineFinished = true;
    }
    private void OnOrderDelivered()
    {
        _clientModel.ClientStatus = ClientStatus.LeavingTheTable;
        _orderController.ChangeOrderState(false);
        _clientView.ChangeMoodState(true);
        Debug.Log($"OnOrderDelivered");
        
    }
    private void OnCoroutineEnded()
    {
        _isCurrentCoroutineFinished = true;
        _clientModel.ClientStatus += 1;
        Debug.Log($"OnCoroutineEnded{_isCurrentCoroutineFinished} {_clientModel.ClientStatus}");
    }

    private void Update()
    {
        if (!_isCurrentCoroutineFinished || _clientModel == null )
        {
            return;
        }
        if ( _clientModel.ClientStatus == ClientStatus.GoingToTheTable)
        {
            _isCurrentCoroutineFinished = false;
            StartCoroutine(_clientView.MoveToKitchen());
        }
        else if (_clientModel.ClientStatus == ClientStatus.WaitingTheOrder)
        {
            // _isCurrentCoroutineFinished = false;
            _clientView.Wait(_clientModel.WaitingTime);
        }
        else if (_clientModel.ClientStatus == ClientStatus.LeavingTheTable)
        {
            _isCurrentCoroutineFinished = false;
            StartCoroutine(_clientView.LeaveKitchen());
        }
    }


    private void OnDestroy()
    {
        _clientView.ActionIsOver -= OnCoroutineEnded;
    }
}