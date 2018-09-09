using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHedgehogs : MonoBehaviour
{
    [SerializeField] GameObject hedgehog;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousePos, 1 << LayerMask.NameToLayer("Hedgehog"));
            if (!hit)
            {
                GameObject hh = PoolManager.GetObject(hedgehog.name, Vector3.zero, mousePos);
                float randomScale = Random.Range(Settings.Instance.settings.minSizeHedgehog, Settings.Instance.settings.maxSizeHedgehog);
                hh.transform.DOScale(Vector3.one * randomScale, Settings.Instance.settings.duration);
                Debug.Log("<color=green>Из пула взят ёжик</color>");
            }
        }
    }
}
