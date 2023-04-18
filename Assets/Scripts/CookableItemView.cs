using UnityEngine;
using UnityEngine.UI;

public class CookableItemView : MonoBehaviour
{
    public Vector3 StartPosition { get; private set; }
    
    [field: SerializeField]
    public CanvasGroup CanvasGroup { get; private set; }
    
    [SerializeField]
    private Image _currentStateView;

    [SerializeField]
    private Sprite _initialStateSprite;
    
    [SerializeField]
    private Sprite _readyStateSprite;

    private void Awake()
    {
        _currentStateView.sprite = _initialStateSprite;
    }

    public void ChangeReadyState(bool flag)
    {
        _currentStateView.sprite = flag ? _readyStateSprite : _initialStateSprite;
    }

    public void SetPosition(RectTransform rectTransform)
    {
        transform.SetParent(rectTransform);
        transform.position = rectTransform.position;
        StartPosition = rectTransform.position;
    }
}