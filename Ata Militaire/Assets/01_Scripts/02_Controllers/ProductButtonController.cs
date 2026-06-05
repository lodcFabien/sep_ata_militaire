using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ProductButtonController : MonoBehaviour
{
    [SerializeField] private Image _clickImage;
    [SerializeField] private ProductModel _product;


    private void Awake()
    {
        _clickImage.color = new Color(0, 0, 0, 0);
    }

    public void Click()
    {
        VoletManager.Instance.SetState(Enums.AppState.Popup);
        PlatesManager.Instance.SetNoPlate(() => { });
        StopAllCoroutines();
        StartCoroutine(WaitForPopup());
    }

    private IEnumerator WaitForPopup()
    {
        yield return new WaitForSeconds(.7f);
        PopupManager.Instance.Populate(_product);
    }
}
