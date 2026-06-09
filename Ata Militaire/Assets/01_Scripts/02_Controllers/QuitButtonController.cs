using System.Collections;
using UnityEngine;

public class QuitButtonController : MonoBehaviour
{
    private int _count = 0;

    public void OnClick()
    {
        StopAllCoroutines();
        StartCoroutine(ResetClicks());
        _count++;

        if(_count > 4)
        {
            Application.Quit();
        }

    }

    private IEnumerator ResetClicks()
    {
        yield return new WaitForSeconds(2f);
        _count = 0; 
    }
}
