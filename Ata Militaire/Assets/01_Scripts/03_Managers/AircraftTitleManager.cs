using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Components;
using static Enums;

public class AircraftTitleManager : Singleton<AircraftTitleManager>
{
    [SerializeField] private Animator _animator;
    [SerializeField] private LocalizeStringEvent _title;


    public void SetCurrentTitle(PlateType planeType)
    {
        if (planeType == PlateType.None)
        {
            _animator.SetBool("Visible", false);
        }
        else
        {
            _animator.SetBool("Visible", true);
            _title.SetEntry(GetCurrentTitle(planeType));
        }
    }


    private string GetCurrentTitle(PlateType planeType) 
    {
        switch (planeType)
        {
            case PlateType.Transport: return "TRANSPORT_TITLE";
            case PlateType.Fighter: return "FIGHTER_TITLE";
            case PlateType.Helico: return "HELICO_TITLE";
            case PlateType.Drone: return "DRONE_TITLE";
        }

        return string.Empty;
    }
}
