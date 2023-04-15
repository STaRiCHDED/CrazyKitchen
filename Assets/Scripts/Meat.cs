using Services;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Meat : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    [field:SerializeField]
    public Image MeatImage { get; private set;}
    
    [field: SerializeField]
    public bool IsCooked { get; private set; }

    public void SetPosition(RectTransform parentTransformPosition,Vector3 position)
    {
        transform.SetParent(parentTransformPosition);
        transform.position = position;

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }
}