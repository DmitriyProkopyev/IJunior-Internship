using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float RandomRotation => Random.Range(0f, 1f) * _speed;

    private float _x;
    private float _y;
    private float _z;

    private void Start()
    {
        Time.timeScale = 1;
        _x = RandomRotation;
        _y = RandomRotation;
        _z = RandomRotation;
    }

    private void Update()
    {
        transform.Rotate(_x * Time.deltaTime, _y * Time.deltaTime, _z * Time.deltaTime);
    }
}
