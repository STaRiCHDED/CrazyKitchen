using UnityEngine;
using UnityEngine.UI;

public class Meat : MonoBehaviour
{
    [field:SerializeField]
    public Image MeatImage { get; private set;}
    
    [field: SerializeField]
    public bool IsCooked { get; private set; }

    public void SetPosition(RectTransform parentTransformPosition)
    {
        transform.SetParent(parentTransformPosition);
        transform.position = parentTransformPosition.position;

    }
}