using System;
using System.Collections.Generic;
using UnityEngine;
using static Enums;

public class PlatesManager : Singleton<PlatesManager>
{
    [SerializeField] private List<PlateController> _plates = new List<PlateController>();

    private PlateController _currentPlate;

    private PlateController _previousPlate;
    public PlateController PreviousPlate => _previousPlate;

    private void OnEnable()
    {
        SetNoPlate(null);
    }

    public void SetCurrentPlate(PlateType type)
    {
        PlateController nextPlate = _plates.Find(x => x.Type == type);

        if (nextPlate == _currentPlate && PopupManager.Instance.CurrentModel == null)
        {
            return;
        }

        if(type != PlateType.None)
        {
            PlatesMenuManager.Instance.SetSelectedButton(type);
        }

        // Hide popup  and title when we change plate
        if (PopupManager.Instance.CurrentModel != null)
        {
            PopupManager.Instance.Populate(null);

            // only hide title if we change plate
            if(type != _previousPlate.Type)
            {
                AircraftTitleManager.Instance.SetCurrentTitle(PlateType.None);
            }
        }

        VoletManager.Instance.SetState(AppState.Plate);

        // if there is no plate just display 
        if (_currentPlate == null)
        {
            nextPlate.SetVisibility(true, () => {
                _currentPlate = nextPlate;
                AircraftTitleManager.Instance.SetCurrentTitle(type);
            });
        }
        // else hide the previous one and show the next one
        else
        {        
            PlatesMenuManager.Instance.SetSelectedButton(type);

            AircraftTitleManager.Instance.SetCurrentTitle(PlateType.None);
            SetNoPlate(() =>
            {
                nextPlate.SetVisibility(true, () =>
                {
                    AircraftTitleManager.Instance.SetCurrentTitle(type);
                    _currentPlate = nextPlate;
                });
            });

        }
    }

    public void SetNoPlate(Action callback)
    {
        _previousPlate = _currentPlate;
        if (_currentPlate != null)
        {
            _currentPlate.SetVisibility(false, () => {
                _currentPlate = null;
                callback.Invoke();
            });
        }
        else
        {
            _currentPlate = null;
        }
    }
}
