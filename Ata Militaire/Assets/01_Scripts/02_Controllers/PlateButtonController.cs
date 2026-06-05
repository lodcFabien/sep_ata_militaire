using UnityEngine;
using static Enums;

public class PlateButtonController : MonoBehaviour
{
    [SerializeField] private bool _fromMainMenu;
    [SerializeField] private PlateType _plateType;

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
}
