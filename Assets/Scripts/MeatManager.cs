using System;
using Pools;
using UnityEngine;
using UnityEngine.UI;

public class MeatManager : MonoBehaviour
{
    [SerializeField] private MeatController _meatControllerPrefab;
    [SerializeField] private Transform _spawnRoot;
    [field:SerializeField] public Button MeatButton { get; private set; }

    private MonoBehaviourPool<MeatController> _pool;

    private void Awake()
    {
        _pool = new MonoBehaviourPool<MeatController>(_meatControllerPrefab, _spawnRoot, 6);
    }

    public MeatController SpawnMeat()
    {
        var meat = _pool.Take();
        return meat;
    }
}