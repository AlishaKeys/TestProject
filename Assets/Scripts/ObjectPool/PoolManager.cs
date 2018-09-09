using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PoolManager
{
    private static Part[] pools;

    [System.Serializable]
    public struct Part
    {
        [Tooltip("Имя префаба")]
        public string name;
        [Tooltip("Образец")]
        public PoolObject prefab;
        [Tooltip("Количество объектов при инициализации пула")]
        public int count;
        [HideInInspector]
        [Tooltip("Сам пул")]
        public ObjectPooling pool;
        [Tooltip("Родитель создаваемых объектов")]
        public Transform parent;
        [Tooltip("Включать на старте")]
        public bool createOnStart;
    }

    /// <summary>
    /// Инициализации массива структур
    /// </summary>
    /// <param name="newPools">Массив структур</param>
    public static void Initialize(Part[] newPools)
    {
        pools = newPools;
        for (int i = 0; i < pools.Length; i++)
        {
            if (pools[i].prefab != null)
            {
                pools[i].pool = new ObjectPooling(); 
                pools[i].pool.Initialize(pools[i].count, pools[i].prefab, pools[i].parent, pools[i].createOnStart);                
            }
        }
    }

    /// <summary>
    /// Проверка на существующие пулы, если находится правильный — вызывается метод GetObject() у класса ObjectPooling
    /// </summary>
    /// <param name="name">Имя префаба пула</param>
    /// <param name="size">Размер создаваемого объекта</param>
    /// <param name="position">Позиция на сцене</param>
    public static GameObject GetObject(string name, Vector2 size, Vector2 position)
    {
        GameObject result = null;
        if (pools != null)
        {
            for (int i = 0; i < pools.Length; i++)
            {
                if (string.Compare(pools[i].name, name) == 0)
                { 
                    result = pools[i].pool.GetObject().gameObject; 
                    result.transform.localScale = size;
                    result.transform.position = position;
                    result.SetActive(true);
                    return result;
                }
            }
        }
        return result;
    }
}
