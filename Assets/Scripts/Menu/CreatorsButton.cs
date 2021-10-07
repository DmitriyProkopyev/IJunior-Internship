using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorsButton : MenuButton
{
    [SerializeField] private GameObject _panel;

    protected override void OnClick() => _panel.SetActive(!_panel.activeSelf);
}
