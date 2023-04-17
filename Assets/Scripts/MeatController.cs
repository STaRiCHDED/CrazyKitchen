using Services;
using UnityEngine;
using UnityEngine.EventSystems;

public class MeatController : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public MeatView MeatView => _meatView;
    
    [SerializeField] private MeatView _meatView;
    
    [SerializeField]
    private MeatModel _meatModel;
    
    public void ChangeMeatState()
    {
        _meatModel.IsCooked = true;
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
        _meatView.Group.blocksRaycasts = false;
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
        Debug.LogWarning($"{element.name}");
        
        if (!element.CompareTag("Plate"))
        {
            transform.position = _meatView.PanPosition;
        }
        Debug.Log("Отпустил мясо");
        _meatView.Group.blocksRaycasts = true;
    }
    
    
    
}