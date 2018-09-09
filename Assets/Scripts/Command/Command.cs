using UnityEngine;
using System.Collections;
using DG.Tweening;

public abstract class Command
{
    /// <summary>
    /// Выполнение операции
    /// </summary>
    /// <param name="command">Наша команда</param>
    /// <param name="currentScale">Стартовый размер объекта, </param>
    /// <param name = "transform">Трансформ для скейла</param>
    public abstract void Execute(Command command, Vector3 currentScale, Transform transform);
}

public class Touch : Command
{
    public override void Execute(Command command, Vector3 currentScale, Transform transform)
    {
        var mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOScale(currentScale * Settings.Instance.settings.touch, Settings.Instance.settings.duration))
        .Append(transform.DOScale(currentScale, Settings.Instance.settings.duration));
        InputHandler.oldCommands.Add(command);
    }
}

public class Jump : Command
{
    Rigidbody2D rb;

    public override void Execute(Command command, Vector3 currentScale, Transform transform)
    {
        float randomForce = Random.Range(Settings.Instance.settings.minForceHedgehog, Settings.Instance.settings.maxForceHedgehog);
        rb = transform.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(0, randomForce, 0), ForceMode2D.Impulse);
        float randomRotate = Random.Range(0, 360);
        transform.DORotate(Vector3.forward * randomRotate, Settings.Instance.settings.duration);
        InputHandler.oldCommands.Add(command);
    }
}

