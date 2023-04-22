using System;
using B.Controllers;
using Pools;
using UnityEngine;
using UnityEngine.UI;

namespace B.Managers
{
    public class CookableIngredientManager : MonoBehaviour
    {
        [field: SerializeField]
        public Button CookableIngredientButton { get; private set; }
        
        [SerializeField]
        private CookableIngredientController _cookableIngredientControllerPrefab;

        [SerializeField]
        private Transform _spawnRoot;

        private MonoBehaviourPool<CookableIngredientController> _pool;

        private void Awake()
        {
            _pool = new MonoBehaviourPool<CookableIngredientController>(_cookableIngredientControllerPrefab,
                _spawnRoot);
        }

        public CookableIngredientController GetCookableIngredient()
        {
            return _pool.Take();
        }

        public void ReleaseCookableIngredient(CookableIngredientController cookableIngredientController)
        {
            _pool.Release(cookableIngredientController);
        }
        
        
    }
}