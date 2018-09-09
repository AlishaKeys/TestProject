using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pool : MonoBehaviour
{
    [Tooltip("Cтруктуры для использования в пуле")]
    [SerializeField] private PoolManager.Part[] pools;

    void OnValidate()
    {
        for (int i = 0; i < pools.Length; i++)
        {
            if (pools[i].prefab)
            {
                pools[i].name = pools[i].prefab.name;            
            }
        }
    }

    void Awake()
    {
        Initialize();
    }

    /// <summary>
    /// Инициализируем Пул
    /// </summary>
    void Initialize()
    {
        PoolManager.Initialize(pools); 
    }
}
