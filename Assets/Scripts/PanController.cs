using UnityEngine;
using UnityEngine.UI;

public class PanController : MonoBehaviour
{
    //todo в дальнейшем удалить с этого класса.тест 
    [SerializeField] private Button _meat;
    
    [SerializeField] private PanView _panView;
    private PanModel _panModel;

    private void Awake()
    {
        _meat.onClick.AddListener(StartCooking);
    }

    public void Initialize(PanModel panModel)
    {
        _panModel = panModel;
    }

    private void StartCooking()
    {
        if (_panModel.IsEmpty)
        {
            _panView.CookMeat(_panModel.CookingTime);
            _panModel.IsEmpty = false;
        }
    }
}