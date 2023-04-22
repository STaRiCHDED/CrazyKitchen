using System;
using B.Events;
using B.Models;
using B.Views;
using UnityEngine;

namespace B.Controllers
{
    public class CookingUtensilController : MonoBehaviour
    {
        [SerializeField]
        private CookingUtensilView _cookingUtensilView;

        [SerializeField]
        private RectTransform _ingredientRoot;
        
        private CookingUtensilModel _cookingUtensilModel;
        private CookableIngredientController _cookableIngredientController;
        private float _currentTime;
        
        public void Initialize(CookingUtensilModel cookingUtensilModel, CookableIngredientController cookableIngredientController)
        {
            _cookingUtensilModel = cookingUtensilModel;
            _cookableIngredientController = cookableIngredientController;
            _cookingUtensilModel.IsAvailable = false;
            _cookableIngredientController.SetPosition(_ingredientRoot);
        }

        private void Cook()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime>=_cookingUtensilModel.CookingTime)
            {
                _currentTime = 0;
                _cookableIngredientController.ChangeState(true);
            }
        }

        private void Update()
        {
            if (_cookingUtensilModel == null || !_cookingUtensilModel.IsAvailable)
            {
               return;
            }
            Cook();
        }
    }
}