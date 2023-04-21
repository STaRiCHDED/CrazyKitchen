﻿using System;
using UnityEngine;

[Serializable]
public class PlateModel
{
    [field: SerializeField]
    public bool IsAvailable { get; set; }

    public PlateModel(bool isAvailable)
    {
       IsAvailable = isAvailable;
    }
    
}