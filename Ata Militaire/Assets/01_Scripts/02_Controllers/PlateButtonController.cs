using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization.SmartFormat.Core.Parsing;
using UnityEngine.UI;
using static Enums;

public class PlateButtonController : MonoBehaviour
{
    [SerializeField] private bool _fromMainMenu;

    [SerializeField] private PlateType _plateType;
    public PlateType PlateType => _plateType;

    [SerializeField] private Image _normalImage;
    [SerializeField] private Image _selectImage;

    private bool _selected = false;

    private void Awake()
    {
        SetSelected(false);
    }

    private void OnEnable()
    {
        OnHoverStop();
    }

    public void Click()
    {
        if (_fromMainMenu)
        {
            ClickFromMainMenu();
        }
        else
        {
            if (_selected)
            {
                PlatesManager.Instance.SetCurrentPlate(PlatesManager.Instance.PreviousPlate.Type);
                PopupManager.Instance.OnBackStopHasContent();
            }
            else
            {
                PopupManager.Instance.hasContent = false;
                PlatesManager.Instance.SetCurrentPlate(_plateType);
            }
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
        _selected = selected;

        _normalImage.gameObject.SetActive(!selected);
        _selectImage.gameObject.SetActive(selected);
    }

    public void OnHoverStart()
    {
        if (!_fromMainMenu)
        {
            return;
        }

        _normalImage.gameObject.SetActive(false);
        _selectImage.gameObject.SetActive(true);
    }

    public void OnHoverStop()
    {
        if (!_fromMainMenu)
        {
            return;
        }

        _normalImage.gameObject.SetActive(true);
        _selectImage.gameObject.SetActive(false);

    }
}
