using System;
using Services;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        var serviceLocator = ServiceLocator.Instance;
        serviceLocator.RegisterSingle<IDragBufferService>(new DragBufferService());
    }
}