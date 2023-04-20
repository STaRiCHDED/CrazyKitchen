using System;
using UnityEngine;
using UnityEngine.UI;

public class PlatesManager : MonoBehaviour
{
    [SerializeField] private PlateController[] _plateController;
    [SerializeField] Button _bunButton;

    private PlateModel[] _plateModels;

    public void Initialize(PlateModel[] plateModels)
    {
        _plateModels = plateModels;
    }
    

    private void Awake()
    {
        _bunButton.onClick.AddListener(OnClicked);
    }

    private void OnClicked()
    {
        for (var i = 0; i < _plateModels.Length; i++)
        {
            if (_plateModels[i].IsAvailable)
            {
                _plateController[i].Initialize(_plateModels[i]);
                return;
            }
        }
    }
    
}