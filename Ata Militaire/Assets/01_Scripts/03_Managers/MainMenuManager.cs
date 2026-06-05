using System;
using System.Collections;
using UnityEngine;

public class MainMenuManager : Singleton<MainMenuManager>
{
    [SerializeField] private Animator _animator;

    private bool _animPlaying = false;

    private bool _visible = true;

    public void SetAnimPlaying(int playing)
    {
        _animPlaying = playing == 1;
    }

    public void SetVisibility(bool visible, Action callback)
    {
        if (_visible == visible)
        {
            callback.Invoke();
            return;
        }
        _visible = visible;

        StopAllCoroutines();
        StartCoroutine(SetVisibilityCoroutine(visible, () => {
            callback.Invoke();
        }));
    }

    private IEnumerator SetVisibilityCoroutine(bool visible, Action callback)
    {
        _animPlaying = true;
        _animator.SetBool("Visible", visible);
        while (_animPlaying)
        {
            yield return new WaitForEndOfFrame();
        }
        callback.Invoke();  
    }
}
