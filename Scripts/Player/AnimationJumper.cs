using System.Collections;
using UnityEngine;

[RequireComponent(typeof(KeyboardInput))]
public class AnimationJumper : MonoBehaviour
{
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private float _duration;
    [SerializeField] private float _scale;

    private KeyboardInput _input;
    private bool _isJumping = false;

    private void OnEnable()
    {
        _input = GetComponent<KeyboardInput>();
        _input.JumpButtonClicked += OnJumpButtonClicked;
    }

    private void OnDisable()
    {
        _input.JumpButtonClicked -= OnJumpButtonClicked;
    }

    private void OnJumpButtonClicked()
    {
        if (_isJumping == false)
            StartCoroutine(Jump());
    }

    private IEnumerator Jump()
    {
        _isJumping = true;
        float expiredTime = 0f;
        float nextYPosition = 0f;
        float progress = 0f;
        float basicPosition = transform.position.y;
        Vector3 newPosition = transform.position;

        while (expiredTime < _duration)
        {
            expiredTime += Time.deltaTime;
            progress = expiredTime / _duration;

            nextYPosition = _curve.Evaluate(progress) * _scale;
            newPosition = new Vector3(transform.position.x, nextYPosition + basicPosition, transform.position.z);

            transform.position = newPosition;
            yield return null;
        }

        _isJumping = false;
    }
}
