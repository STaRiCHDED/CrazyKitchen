using B.Controllers;
using Pools;
using UnityEngine;
using UnityEngine.UI;

namespace B.Managers
{
    public class IngredientManager : MonoBehaviour
    {
        [field: SerializeField]
        public Button IngredientButton { get; private set; }
        
        [SerializeField]
        private IngredientController _ingredientControllerPrefab;

        [SerializeField]
        private Transform _spawnRoot;

        private MonoBehaviourPool<IngredientController> _pool;

        private void Awake()
        {
            _pool = new MonoBehaviourPool<IngredientController>(_ingredientControllerPrefab,
                _spawnRoot);
        }

        public IngredientController GetCookableIngredient()
        {
            return _pool.Take();
        }

        public void ReleaseCookableIngredient(IngredientController ingredientController)
        {
            _pool.Release(ingredientController);
        }
    }
}