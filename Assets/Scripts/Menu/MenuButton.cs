using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public abstract class MenuButton : MonoBehaviour
{
    private Button _button;

    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable() => _button.onClick.RemoveListener(OnClick);

    protected abstract void OnClick();
}
