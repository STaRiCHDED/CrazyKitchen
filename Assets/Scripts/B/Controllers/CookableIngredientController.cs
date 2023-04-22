using System;
using B.Events;
using B.Interfaces;
using B.Models;
using B.Views;
using Services;
using UnityEngine;
using UnityEngine.EventSystems;

namespace B.Controllers
{
    public class CookableIngredientController : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
    {
        [SerializeField]
        private CookableIngredientView _cookableIngredientView;
        
        [SerializeField]
        private CookableIngredientModel _cookableIngredientModel;

        private Vector3 _rootPosition;
        public void ChangeState(bool isReady)
        {
            _cookableIngredientModel.IsCooked = isReady;
            var sprite = isReady ? _cookableIngredientModel.Completed : _cookableIngredientModel.Uncompleted;
            _cookableIngredientView.DisplayView(sprite);
        }

        public void SetPosition(RectTransform rootTransform)
        {
            _rootPosition = rootTransform.position;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!_cookableIngredientModel.IsCooked)
            {
                return;
            }
            Debug.Log("Взял ингредиент");
            var service = ServiceLocator.Instance.GetSingle<IDragBufferService>();
            service.AddToBuffer(gameObject);
            _cookableIngredientView.CanvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!_cookableIngredientModel.IsCooked)
            {
                return;
            }
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            var element = eventData.pointerCurrentRaycast.gameObject;
            var standable = element.GetComponent<IStandable>();
       
            if (standable==null)
            {
                transform.position = _rootPosition;
            }
        
            Debug.Log("Отпустил ингредиент");
            _cookableIngredientView.CanvasGroup.blocksRaycasts = true;
        }
    }
}