using Services;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Meat : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    [field:SerializeField]
    public Image MeatImage { get; private set;}
    
    [field: SerializeField]
    public bool IsCooked { get; set; }

    [SerializeField] private CanvasGroup _group;

    private Vector3 _panPosition;

    public void SetPosition(RectTransform parentTransformPosition)
    {
        transform.SetParent(parentTransformPosition);
        transform.position = parentTransformPosition.position;
        _panPosition = parentTransformPosition.position;
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!IsCooked)
        {
            return;
        }
        Debug.Log("Взял мясо");
        var service = ServiceLocator.Instance.GetSingle<IDragBufferService>();
        service.AddToBuffer(gameObject);
        _group.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!IsCooked)
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
            gameObject.transform.position = _panPosition;
        }
        Debug.Log("Отпустил мясо");
        _group.blocksRaycasts = true;
    }
}