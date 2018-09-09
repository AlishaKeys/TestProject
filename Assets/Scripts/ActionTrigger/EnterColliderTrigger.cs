using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterColliderTrigger : TriggerBase
{
    public new string tag;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == tag)
        {
            Trigger();
        }
    }
}
