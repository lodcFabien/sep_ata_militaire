using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private EventSystem _eventSystem;

    public void SetInputEnabled(bool enabled)
    {
        _eventSystem.enabled = enabled;
    }
}
