using System;
using System.Collections;
using UnityEngine;
using static Enums;

public class PlateController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlateType _type;
    public PlateType Type => _type;

    private bool _animPlaying;

    bool _visible = false;

    public void SetAnimPlaying(int playing)
    {
        _animPlaying = playing == 1;
    }

    public void SetVisibility(bool visible, Action callback)
    {

        if(visible == _visible)
        {
            callback.Invoke();
            return;
        }

        _visible = visible;

        StopAllCoroutines();    
        StartCoroutine(SetVisibilityCoroutine(visible, () => { callback.Invoke(); }));
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
