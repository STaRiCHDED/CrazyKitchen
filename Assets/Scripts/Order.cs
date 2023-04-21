using Services;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Order : MonoBehaviour, IDropHandler
{
    public Image OrderView => _orderView;
    
    [SerializeField] private Image _orderView;
    
    public void OnDrop(PointerEventData eventData)
    {
        var ingredient = ServiceLocator.Instance.GetSingle<IDragBufferService>().GetElement();
        
    }
    
}