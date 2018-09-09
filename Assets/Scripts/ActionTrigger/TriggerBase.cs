using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggerBase : MonoBehaviour
{
    ActionBase action;

    protected virtual void Start()
    {
        if (action == null)
        {
            action = GetComponent<ActionBase>();
            if (action == null)
            {
                throw new Exception("Экшон на: " + gameObject.name + " не найден");
            }
        }
    }

    public void Trigger()
    {
        if (action)
        {
            action.Act();
        }
    }
}
