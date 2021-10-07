using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AnimationJumper))]
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _coinPrice;
    [SerializeField] private float _obstaclePrice;

    public event UnityAction<IPoolable> CoinCollected;
    public event UnityAction<Obstacle> ObstacleHit;
    public event UnityAction GameOver;

    private void Start()
    {
        var collider = GetComponent<SphereCollider>();
        var rigidbody = GetComponent<Rigidbody>();

        collider.isTrigger = true;
        rigidbody.useGravity = false;
        rigidbody.isKinematic = false;

        Time.timeScale = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Obstacle obstacle))
            HitTheObstacle(obstacle);

        if (other.TryGetComponent(out Coin coin))
            Collect(coin);
    }

    private void HitTheObstacle(Obstacle obstacle)
    {
        if (Time.timeScale <= _obstaclePrice)
        {
            GameOver?.Invoke();
            return;
        }

        Time.timeScale -= _obstaclePrice;
        ObstacleHit?.Invoke(obstacle);
    }

    private void Collect(Coin coin)
    {
        CoinCollected?.Invoke(coin as IPoolable);
        Time.timeScale += _coinPrice;
    }
}
