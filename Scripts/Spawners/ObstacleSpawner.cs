using System.Collections;
using UnityEngine;

public class ObstacleSpawner : Spawner
{
    [SerializeField] private Obstacle _template;
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;

    private Pool<Obstacle> _pool;

    private void Start()
    {
        _pool = new Pool<Obstacle>(_template);
        Spawn();
    }

    protected override void Spawn() => StartCoroutine(SpawnWithDelay());

    private IEnumerator SpawnWithDelay()
    {
        while (true)
        {
            float delay = Random.Range(_minDelay, _maxDelay);
            var wait = new WaitForSeconds(delay);

            var obstacle = _pool.Take();
            obstacle.transform.position = transform.position;
            obstacle.transform.parent = transform;
            yield return wait;
        }
    }

    protected override void PutInPool(IPoolable poolable)
    {
        if (poolable is Obstacle)
            _pool.Put(poolable as Obstacle);
    }
}
