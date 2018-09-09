using DG.Tweening;
using UnityEngine;

public class FallAction : ActionBase
{
    /// <summary>
    /// Поворот ёжика на лапки
    /// </summary>
    public override void Act()
    {
        base.Act();
        transform.DORotate(Vector3.zero, Settings.Instance.settings.duration);
    }
}