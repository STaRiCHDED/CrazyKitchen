using Services;
using UnityEngine;
using UnityEngine.EventSystems;

public class MeatController : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public MeatView MeatView => _meatView;
    
    [SerializeField] private MeatView _meatView;
    
    [SerializeField]
    private MeatModel _meatModel;

    public void BlockRaycasts(bool flag)
    {
        _meatView.CanvasGroup.blocksRaycasts = flag;
    }
    public void ChangeMeatState(bool isReady)
    {
        _meatModel.IsCooked = isReady;
        _meatView.ChangeReadyState(isReady);
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!_meatModel.IsCooked)
        {
            return;
        }
        Debug.Log("Взял мясо");
        var service = ServiceLocator.Instance.GetSingle<IDragBufferService>();
        service.AddToBuffer(gameObject);
        BlockRaycasts(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!_meatModel.IsCooked)
        {
            return;
        }
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var element = eventData.pointerCurrentRaycast.gameObject;
        var plate = element.GetComponent<PlateController>();
       
        if (plate==null || plate.CurrentMealStatus is MealStatus.Empty or MealStatus.Completed)
        {
            transform.position = _meatView.StartPosition;
        }
        
        Debug.Log("Отпустил мясо");
        BlockRaycasts(true);
    }
    
    
    
}