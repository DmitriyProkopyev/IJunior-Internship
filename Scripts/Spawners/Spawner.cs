using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] private MovingObjectsRemover _remover;

    private void OnEnable()
    {
        _remover.PoolableObjectTriggered += PutInPool;
    }

    private void OnDisable()
    {
        _remover.PoolableObjectTriggered -= PutInPool;
    }

    protected abstract void Spawn();

    protected abstract void PutInPool(IPoolable poolable);
}
