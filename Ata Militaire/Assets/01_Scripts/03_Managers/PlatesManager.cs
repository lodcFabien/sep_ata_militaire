using System;
using System.Collections.Generic;
using UnityEngine;
using static Enums;

public class PlatesManager : Singleton<PlatesManager>
{
    [SerializeField] private List<PlateController> _plates = new List<PlateController>();

    private PlateController _currentPlate;

    private void OnEnable()
    {
        SetNoPlate(null);
    }

    public void SetCurrentPlate(PlateType type)
    {
        PlateController nextPlate = _plates.Find(x => x.Type == type);

        if (nextPlate == _currentPlate)
        {
            return;
        }

        VoletManager.Instance.SetState(AppState.Plate);
        if (_currentPlate == null)
        {
            nextPlate.SetVisibility(true, () => {
                _currentPlate = nextPlate;
            });
        }
        else
        {
            SetNoPlate(() =>
            {
                nextPlate.SetVisibility(true, () =>
                {
                    _currentPlate = nextPlate;
                });
            });

        }
    }

    public void SetNoPlate(Action callback)
    {
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
