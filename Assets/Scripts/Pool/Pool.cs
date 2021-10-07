using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour, IPoolable
{
    private Queue<T> _pooledObjects;
    private T _template;
     
    public Pool(T template)
    {
        _template = template;
        _pooledObjects = new Queue<T>();
    }

    public T Take()
    {
        if (_pooledObjects.Count > 0)
            return Activate(_pooledObjects.Dequeue());

        return Activate(GameObject.Instantiate(_template)); 
    }

    public void Put(T pooledObject)
    {
        Disactivate(pooledObject);
        _pooledObjects.Enqueue(pooledObject);
    }

    private T Activate(T pooledObject)
    {
        pooledObject.gameObject.SetActive(true);
        pooledObject.enabled = true;
        return pooledObject;
    }

    private T Disactivate(T pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
        pooledObject.enabled = false;
        return pooledObject;
    }
}
