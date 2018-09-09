using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    /// <summary>
    /// Вернуть объект обратно в пул
    /// </summary>
    public void ReturnToPool()
    {
        gameObject.SetActive(false);
    }

    private void OnBecameInvisible()
    {
        ReturnToPool();
    }
}
