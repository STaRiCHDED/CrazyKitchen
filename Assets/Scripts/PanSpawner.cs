using UnityEngine;
using UnityEngine.UI;

public class PanSpawner : MonoBehaviour
{
    //todo в дальнейшем удалить с этого класса.тест 
    [SerializeField] private Button _meat;

    [SerializeField] private RectTransform _spawnRoot;
    [SerializeField] private PanController _panPrefab;

    private void Awake()
    {
        _meat.onClick.AddListener(Spawn);
    }

    private void Spawn()
    {
        var pan = Instantiate(_panPrefab, _spawnRoot);
        pan.Initialize(new PanModel(3));
    }
}