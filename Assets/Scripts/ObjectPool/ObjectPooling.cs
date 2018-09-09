using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour, ICreationPool<PoolObject>
{
    List<PoolObject> objects;
    Transform objectsParent;

    public void AddObject(PoolObject sample, Transform objectsParent, bool createOnStart)
    {
        GameObject tempObj = Instantiate(sample.gameObject, objectsParent);
        tempObj.name = sample.name;
        objects.Add(tempObj.GetComponent<PoolObject>());        
        tempObj.SetActive(createOnStart);
    }

    public PoolObject GetObject()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (!objects[i].gameObject.activeInHierarchy)
            {
                return objects[i];
            }
        }
        return objects[objects.Count - 1];
    }

    public void Initialize(int count, PoolObject sample, Transform objectsParent, bool createOnStart)
    {
        objects = new List<PoolObject>(); 
        this.objectsParent = objectsParent; 
        for (int i = 0; i < count; i++)
        {
            //создаем объекты до указанного количества
            AddObject(sample, objectsParent, createOnStart);
        }
    }
}