using System;
using B.Controllers;
using B.Models;
using UnityEngine;

namespace B.Managers
{
    public class CookingUtensilsManager : MonoBehaviour
    {
        [SerializeField]
        private CookingUtensilController[] _cookingUtensilControllers;

        [SerializeField]
        private CookableIngredientManager _cookableIngredientManager;

        private CookingUtensilModel[] _cookingUtensilModels;

        public void Initialize(CookingUtensilModel[] cookingUtensilModels)
        {
            _cookingUtensilModels = cookingUtensilModels;
            _cookableIngredientManager.CookableIngredientButton.onClick.AddListener(StartCooking);
        }
        
        private void StartCooking()
        {
            for (var i = 0; i < _cookingUtensilModels.Length; i++)
            {
                if (_cookingUtensilModels[i].IsAvailable)
                {
                    var ingredient = _cookableIngredientManager.GetCookableIngredient();
                    _cookingUtensilControllers[i].Initialize(_cookingUtensilModels[i], ingredient);
                    return;
                }
            }
        }
    }
}