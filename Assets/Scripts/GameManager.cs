using System;
using Services;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameConfig _config;
    [SerializeField] private PansManager _pansManager;
    
    private void Awake()
    {
        var serviceLocator = ServiceLocator.Instance;
        serviceLocator.RegisterSingle<IDragBufferService>(new DragBufferService());
        
        _pansManager.Initialize(_config.PanModels);
    }
}