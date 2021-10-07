using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]

public class Score : MonoBehaviour
{
    [SerializeField] private Player _player;

    private TMP_Text _text;
    private int _currentScore;

    private void Start()
    {
        _currentScore = 0;
        _text = GetComponent<TMP_Text>();
    }

    private void OnEnable() => _player.CoinCollected += OnCoinCollected;

    private void OnDisable() => _player.CoinCollected -= OnCoinCollected;

    private void OnCoinCollected(IPoolable poolable)
    {
        _currentScore++;
        _text.text = _currentScore.ToString();
    }
}
