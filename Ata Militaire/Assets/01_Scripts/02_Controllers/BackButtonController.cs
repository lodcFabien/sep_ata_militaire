using UnityEngine;

public class BackButtonController : MonoBehaviour
{
    public void Click()
    {
        if(PopupManager.Instance.CurrentModel == null)
        {
            AircraftTitleManager.Instance.SetCurrentTitle(Enums.PlateType.None);
            VoletManager.Instance.SetState(Enums.AppState.MainMenu);
            PlatesMenuManager.Instance.SetVisibility(false);
            PlatesManager.Instance.SetNoPlate(() => {
                MainMenuManager.Instance.SetVisibility(true, () => { });
            });
            PopupManager.Instance.Populate(null);
        }
        else
        {
            PlatesManager.Instance.SetCurrentPlate(PlatesManager.Instance.PreviousPlate.Type);
        }
    }
}
