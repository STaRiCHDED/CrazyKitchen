using Events;
using Models;
using Services;
using UnityEngine;
using UnityEngine.EventSystems;
using Views;

namespace Controllers
{
    public class PlateController : MonoBehaviour, IDropHandler,IBeginDragHandler,IDragHandler,IEndDragHandler
    {
        public Vector3 StartPosition { get; private set; }
        public MealStatus CurrentMealStatus { get; private set; }
        
        [SerializeField]
        private RectTransform _rootTransform;
        
        [SerializeField]
        private PlateView _plateView;
    
        private PlateModel _plateModel;
       

        private void Awake()
        {
            CurrentMealStatus = MealStatus.Empty;
        }

        public void Initialize(PlateModel plateModel)
        {
            _plateModel = plateModel;
            _plateModel.IsAvailable = false;
            _plateView.ChangeMealState(false);
            StartPosition = _rootTransform.position;
            CurrentMealStatus = MealStatus.Uncompleted;
        }

        public void ResetView()
        {
            _plateView.ResetView();
        }

        public bool CompareMeals(Sprite orderMeal)
        {
            return _plateView.PlateImage.sprite == orderMeal;
        }
        
        public void OnDrop(PointerEventData eventData)
        {
            if (CurrentMealStatus is MealStatus.Completed or MealStatus.Empty)
            {
                return;
            }
            var ingredient = ServiceLocator.Instance.GetSingle<IDragBufferService>().GetElement();
            var meatController = ingredient.GetComponent<MeatController>();
            if (meatController != null)
            {
                CurrentMealStatus = MealStatus.Completed;
                _plateView.ChangeMealState(true);
                EventStreams.Game.Publish(new ReleaseMeatRequestEvent(meatController));
                meatController.ChangeMeatState(false);
            
            }
            Debug.Log("Бургер готов");
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (CurrentMealStatus!=MealStatus.Completed)
            {
                return;
            }
            var service = ServiceLocator.Instance.GetSingle<IDragBufferService>();
            service.AddToBuffer(gameObject);
            BlockRaycasts(false);
        }
        
        public void OnDrag(PointerEventData eventData)
        {
            if (CurrentMealStatus!=MealStatus.Completed)
            {
                return;
            }
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            var element = eventData.pointerCurrentRaycast.gameObject;
            var order = element.GetComponent<Order>();

            if (order == null)
            {
                transform.position = StartPosition;
            }
            BlockRaycasts(true);
        }
        
        private void BlockRaycasts(bool shouldBlock)
        {
            _plateView.CanvasGroup.blocksRaycasts = shouldBlock;
        }
    }
}