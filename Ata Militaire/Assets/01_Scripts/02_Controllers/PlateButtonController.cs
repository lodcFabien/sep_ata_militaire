using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static Enums;

public class PlateButtonController : MonoBehaviour
{
    [SerializeField] private bool _fromMainMenu;

    [SerializeField] private PlateType _plateType;
    public PlateType PlateType => _plateType;

    [SerializeField] private Image _normalImage;
    [SerializeField] private Image _selectImage;

    private void Awake()
    {
        SetSelected(false);
    }

    public void Click()
    {
        if (_fromMainMenu)
        {
            ClickFromMainMenu();
        }
        else
        {
            PlatesManager.Instance.SetCurrentPlate(_plateType);
        }
    }

    private void ClickFromMainMenu()
    {
        MainMenuManager.Instance.SetVisibility(false, () =>
        {
            PlatesManager.Instance.SetCurrentPlate(_plateType);

            PlatesMenuManager.Instance.SetVisibility(true);
        });
    }

    public void SetSelected(bool selected)
    {
        Debug.Log(selected);

        _normalImage.gameObject.SetActive(!selected);
        _selectImage.gameObject.SetActive(selected);
    }
}
