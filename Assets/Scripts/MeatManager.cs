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
    private IDisposable _subscription;

    private void Awake()
    {
        _pool = new MonoBehaviourPool<MeatController>(_meatControllerPrefab, _spawnRoot, 6);
        _subscription=EventStreams.Game.Subscribe<ReleaseMeatRequest>(ReleaseMeat);
    }

    public MeatController SpawnMeat()
    {
        var meat = _pool.Take();
        return meat;
    }

    public void ReleaseMeat(ReleaseMeatRequest eventData)
    {
        _pool.Release(eventData.MeatController);
    }

    private void OnDestroy()
    {
        _subscription.Dispose();
    }
}