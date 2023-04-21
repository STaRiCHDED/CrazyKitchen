using System.Collections;
using Managers;
using Services;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameConfig _config;
    
    [SerializeField]
    private PansManager _pansManager;
    
    [SerializeField]
    private PlatesManager _platesManager;

    [SerializeField]
    private Client _client;
    
    private void Awake()
    {
        var serviceLocator = ServiceLocator.Instance;
        serviceLocator.RegisterSingle<IDragBufferService>(new DragBufferService());
        
        _pansManager.Initialize(_config.PanModels);
        _platesManager.Initialize(_config.PlateModels);
        StartCoroutine(ShowOrder());
    }

    private IEnumerator ShowOrder()
    {
        yield return new WaitForSeconds(5);
        _client.UpdateOrderState(true);
    }
}