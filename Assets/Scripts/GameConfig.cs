using Models;
using UnityEngine;

[CreateAssetMenu(menuName = "GameConfig", fileName = "GameConfig")]
public class GameConfig : ScriptableObject
{
    public PanModel[] PanModels => _panModels;
    public PlateModel[] PlateModels => _plateModels;

    [SerializeField]
    private PanModel[] _panModels;
    
    [SerializeField]
    private PlateModel[] _plateModels;
}