using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using static Enums;

public class PlatesMenuManager : Singleton<PlatesMenuManager>
{
    [SerializeField] private Animator _animator;
    [SerializeField] private List<PlateButtonController> _buttons;
    
    public void SetVisibility(bool visible)
    {
        _animator.SetBool("Visible", visible);
    }

    public void SetSelectedButton(PlateType type)
    {
        _buttons.ForEach(x => x.SetSelected(x.PlateType == type));
    }
}
