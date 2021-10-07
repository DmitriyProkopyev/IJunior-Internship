using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using IJunior.TypedScenes;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private Image _blackScreen;
    [SerializeField] private Player _player;
    [SerializeField] private float _fadeTime;

    private void OnEnable()
    {
        _player.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _player.GameOver -= OnGameOver;
    }

    private void OnGameOver()
    {
        var tween = _blackScreen.DOFade(1, _fadeTime);
        tween.onComplete += LoadMenu;
    }

    private void LoadMenu() => Menu.Load();
}
