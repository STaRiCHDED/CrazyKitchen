using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSpawner : MonoBehaviour
{
    [SerializeField] 
    private ClientController _clientPrefab;
    [SerializeField] 
    private RectTransform _parentRoot;
    
    //[SerializeField]
    //private ClientModel _clientModel;
    //[SerializeField]
    //private OrderController _orderController;

    private ClientController SpawnedClient;
    private void Start()
    {
        SpawnClient(_parentRoot);
    }

    private void SpawnClient(RectTransform parentRoot)
    {
        SpawnedClient = Instantiate(_clientPrefab, parentRoot);
        //SpawnedClient.Initialize(_clientModel,_orderController,_parentRoot);
        SpawnedClient.Initialize(_parentRoot);
    }
}
