using System;
using UnityEngine;

public class PlatesMenuManager : Singleton<PlatesMenuManager>
{
    [SerializeField] private Animator _animator;
    
    public void SetVisibility(bool visible)
    {
        _animator.SetBool("Visible", visible);
    }

    public void Back()
    {
        SetVisibility(false);
        VoletManager.Instance.SetState(Enums.AppState.MainMenu);
        PlatesManager.Instance.SetNoPlate(() => {
            MainMenuManager.Instance.SetVisibility(true, () => { });
        });
    }
    
}
