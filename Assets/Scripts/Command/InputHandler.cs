using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour
{
    private Command buttonMouseL1, buttonMouseL2;
    public static List<Command> oldCommands = new List<Command>();

    void Start()
    {
        buttonMouseL1 = new Jump();
        buttonMouseL2 = new Touch();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousePos, 1 << LayerMask.NameToLayer("Hedgehog"));
            if (hit)
            {
                buttonMouseL1.Execute(buttonMouseL1, hit.transform.localScale, hit.transform);
                buttonMouseL2.Execute(buttonMouseL2, hit.transform.localScale, hit.transform);
            }
        }
    }
}