using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Settings", order = 1)]
public class SettingsData : ScriptableObject
{
    [Header("Size")]
    public float minSizeHedgehog;
    public float maxSizeHedgehog;
    [Header("Force")]
    public float minForceHedgehog;
    public float maxForceHedgehog;
    [Header("Scale")]
    public float duration;
    public float touch;
}
