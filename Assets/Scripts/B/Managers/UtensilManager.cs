using B.Controllers;
using B.Models;
using UnityEngine;

namespace B.Managers
{
    public class UtensilManager : MonoBehaviour
    {
        [SerializeField]
        private UtensilController[] _utensilControllers;

        [SerializeField]
        private IngredientManager _ingredientManager;
        
        private UtensilModel[] _utensilModels;

        public void Initialize(UtensilModel[] utensilModels)
        {
            _utensilModels = utensilModels;
            _ingredientManager.IngredientButton.onClick.AddListener(PutIngredient);
        }
        
        private void PutIngredient()
        {
            for (var i = 0; i < _utensilModels.Length; i++)
            {
                if (_utensilModels[i].IsAvailable)
                {
                    var ingredient = _ingredientManager.GetCookableIngredient();
                    _utensilControllers[i].Initialize(_utensilModels[i], ingredient);
                    return;
                }
            }
        }
    }
}