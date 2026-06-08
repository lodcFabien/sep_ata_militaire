using UnityEngine;

public class PlaneAnimatorController : MonoBehaviour
{
    [SerializeField] private RectTransform _thisRectTransform;
    [SerializeField] private RectTransform _followRectTransform;

    private void Update()
    {
        if (PopupManager.Instance.hasContent)
        {
            return;
        }
        _thisRectTransform.position = _followRectTransform.position;
    }
}
