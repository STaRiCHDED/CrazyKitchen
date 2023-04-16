using System.Collections;
using System.Collections.Generic;
using Services;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlateController : MonoBehaviour, IDropHandler
{
    [field: SerializeField] public RectTransform MeatTransform { get; private set; }
    public void OnDrop(PointerEventData eventData)
    {
        var meat = ServiceLocator.Instance.GetSingle<IDragBufferService>().GetElement();
        meat.transform.SetParent(MeatTransform);
        Debug.Log("Тарелка");
    }
}
