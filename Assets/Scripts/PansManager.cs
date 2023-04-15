using System;
using UnityEngine;

public class PansManager : MonoBehaviour
{
    [SerializeField] private PanController[] _pans;
    [SerializeField] private MeatController _meatController;

    private void Awake()
    {
        _meatController.MeatButton.onClick.AddListener(StartCookingMeat);
    }

    private void StartCookingMeat()
    {
        foreach (var panController in _pans)
        {
            if (panController.IsAvailable)
            {
                var meat = _meatController.SpawnMeat();
                panController.Initialize(meat);
                meat.SetPosition(panController.MeatTransform);
                panController.SetPanAvailable(false);
            }
        }
    }
}