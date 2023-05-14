using UnityEngine;
// TODO: Перейти на класс ClientView, этот класс удалить
public class Client : MonoBehaviour
{
    [SerializeField]
    private Order _order;

    public void UpdateOrderState(bool flag)
    {
        _order.gameObject.SetActive(flag);
    }
}