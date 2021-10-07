using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[RequireComponent(typeof(PostProcessVolume))]

public class HitEffect : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _changingSpeed;

    private PostProcessVolume _volume;
    private Vignette _vignette;
    private bool _isPlaying;

    private void Start()
    {
        _volume = GetComponent<PostProcessVolume>();

        if (_volume.profile.TryGetSettings(out _vignette) == false)
            throw new NullReferenceException();
    }

    private void OnEnable() => _player.ObstacleHit += Play;

    private void OnDisable() => _player.ObstacleHit -= Play;

    private void Play(Obstacle obstacle)
    {
        if (_isPlaying == false)
            StartCoroutine(PlayEffect());
    }

    private IEnumerator PlayEffect()
    {
        _isPlaying = true;

        while (_vignette.intensity.value < 1)
        {
            _vignette.intensity.value = Mathf.MoveTowards(_vignette.intensity.value, 1, _changingSpeed);
            yield return null;
        }

        while (_vignette.intensity.value > 0)
        {
            _vignette.intensity.value = Mathf.MoveTowards(_vignette.intensity.value, 0, _changingSpeed);
            yield return null;
        }

        _isPlaying = false;
    }
}
