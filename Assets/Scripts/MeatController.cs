using System;
using Pools;
using UnityEngine;
using UnityEngine.UI;

public class MeatController : MonoBehaviour
{
    [SerializeField] private Meat _meatPrefab;
    [SerializeField] private Transform _spawnRoot;
    [field:SerializeField] public Button MeatButton { get; private set; }

    private MonoBehaviourPool<Meat> _pool;

    private void Awake()
    {
        _pool = new MonoBehaviourPool<Meat>(_meatPrefab, _spawnRoot, 6);
    }

    public Meat SpawnMeat()
    {
        var meat = _pool.Take();
        return meat;
    }
}