using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : Spawner
{
    [SerializeField] private Coin _template;
    [SerializeField] private Player _player;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _distanceFromObstacles;

    private Pool<Coin> _pool;

    private void Start()
    {
        _pool = new Pool<Coin>(_template);
        Spawn();
    }

    private void OnEnable() => _player.CoinCollected += PutInPool;

    private void OnDisable() => _player.CoinCollected -= PutInPool;

    protected override void Spawn() => StartCoroutine(SpawnWhenPossible());

    private IEnumerator SpawnWhenPossible()
    {
        var wait = new WaitForSeconds(_spawnDelay);

        while (true)
        {
            if (IsPlaceFree(transform.position))
            {
                var coin = _pool.Take();
                coin.transform.position = transform.position;
                coin.transform.parent = transform;
            }
            yield return wait;
        }
    }

    private bool IsPlaceFree(Vector3 position) => !Physics.CheckSphere(position, _distanceFromObstacles);

    protected override void PutInPool(IPoolable poolable)
    {
        if (poolable is Coin)
            _pool.Put(poolable as Coin);
    }
}
