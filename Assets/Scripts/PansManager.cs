using System;
using System.Collections.Generic;
using UnityEngine;

public class PansManager : MonoBehaviour
{
    [SerializeField] private PanController[] _pans;
    [SerializeField] private MeatController _meatController;

    private List<PanModel> _panModels;

    public void Initialize(List<PanModel> panModels)
    {
        _panModels = panModels;
    }
    
    private void Awake()
    {
        _meatController.MeatButton.onClick.AddListener(StartCookingMeat);
    }

    private void StartCookingMeat()
    {
        for (var i = 0; i < _panModels.Count; i++)
        {
            if (_panModels[i].IsAvailable)
            {
                var meat = _meatController.SpawnMeat();
                _pans[i].Initialize(_panModels[i], meat);
            }
        }
    }
}