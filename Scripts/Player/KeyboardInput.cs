using UnityEngine;
using UnityEngine.Events;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private KeyCode _jumpButton;

    public event UnityAction JumpButtonClicked;

    private void Update()
    {
        if (Input.GetKeyDown(_jumpButton))
            JumpButtonClicked?.Invoke();
    }
}
