using B.Interfaces;
using B.Models;
using B.Views;
using UnityEngine;
using UnityEngine.EventSystems;

namespace B.Controllers
{
    public class UtensilController : MonoBehaviour, IDropHandler, IStandable
    {
        [SerializeField]
        private UtensilView _utensilView;

        private UtensilModel _utensilModel;
        private IngredientController _ingredientController;

        public void Initialize(UtensilModel utensilModel, IngredientController ingredientController)
        {
            _utensilModel = utensilModel;
            _ingredientController = ingredientController;
        }
        
        public void OnDrop(PointerEventData eventData)
        {
            
        }
    }
}