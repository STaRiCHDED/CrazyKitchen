using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameConfig", fileName = "GameConfig")]
public class GameConfig : ScriptableObject
{
    public List<PanModel> PanModels => _panModels;
    
    [SerializeField] private List<PanModel> _panModels;
}