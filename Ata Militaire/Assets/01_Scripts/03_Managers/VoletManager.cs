using UnityEngine;
using static Enums;

public class VoletManager : Singleton<VoletManager>
{
    [SerializeField] private Animator _animator;

    public void SetState(AppState state)
    {
        if(state == AppState.MainMenu)
        {
            _animator.SetInteger("State", 0);
        }
        else if(state == AppState.Plate) 
        {
            _animator.SetInteger("State", 1);
        }
        else if (state == AppState.Popup)
        {
            _animator.SetInteger("State", 2);
        }
    }
}
