using System;
using System.Collections.Generic;
using UnityEngine;

public class PansManager : MonoBehaviour
{
    [SerializeField] private PanController[] _pans;
    [SerializeField] private MeatManager _meatManager;

    private PanModel[] _panModels;

    public void Initialize(PanModel[] panModels)
    {
        _panModels = panModels;
    }

    private void Awake()
    {
        _meatManager.MeatButton.onClick.AddListener(StartCookingMeat);
    }

    private void StartCookingMeat()
    {
        for (var i = 0; i < _panModels.Length; i++)
        {
            if (_panModels[i].IsAvailable)
            {
                var meat = _meatManager.SpawnMeat();
                _pans[i].Initialize(_panModels[i], meat);
            }
        }
    }
}