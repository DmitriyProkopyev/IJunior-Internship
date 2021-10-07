using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Image))]

public class ScreenFader : MonoBehaviour
{
    [SerializeField] private float _duration;

    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
        _image.DOFade(0, _duration);
    }
}
