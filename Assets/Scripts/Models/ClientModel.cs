using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[Serializable]
public class ClientModel : MonoBehaviour
{
    [field: SerializeField]
    public ClientStatus ClientStatus { get; set; }
    
    [field: SerializeField]
    public float WaitingTime { get; private set; }

    public ClientModel(ClientStatus clientStatus, float waitingTime)
    {
        ClientStatus = clientStatus;
        WaitingTime = waitingTime;
    }
}
