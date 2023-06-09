﻿using System;
using Controllers;
using Events;
using Pools;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class MeatManager : MonoBehaviour
    {
        [field:SerializeField]
        public Button MeatButton { get; private set; }
    
        [SerializeField]
        private MeatController _meatControllerPrefab;
    
        [SerializeField]
        private Transform _spawnRoot;
    
        private MonoBehaviourPool<MeatController> _pool;
        private IDisposable _subscription;

        private void Awake()
        {
            _pool = new MonoBehaviourPool<MeatController>(_meatControllerPrefab, _spawnRoot, 2);
            _subscription=EventStreams.Game.Subscribe<ReleaseMeatRequestEvent>(ReleaseMeat);
        }

        public MeatController SpawnMeat()
        {
            var meat = _pool.Take();
            return meat;
        }

        private void ReleaseMeat(ReleaseMeatRequestEvent eventData)
        {
            var meat = eventData.MeatController;
            _pool.Release(meat);
            meat.BlockRaycasts(true);
        
        }

        private void OnDestroy()
        {
            _subscription.Dispose();
        }
    }
}