using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]

public class MovingObjectsRemover : MonoBehaviour
{
    public event UnityAction<IPoolable> PoolableObjectTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IPoolable poolable))
            PoolableObjectTriggered?.Invoke(poolable);
    }
}
