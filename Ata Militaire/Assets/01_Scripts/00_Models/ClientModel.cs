using System;
using UnityEngine;
using static Enums;

public class ClientModel
{
    private string _ip;
    public string Ip => _ip;

    private bool _inputEnabled;
    public bool InputEnabled => _inputEnabled;

    private AppState _currentState;
    public AppState CurrentState => _currentState;

    private float _batteryLevel;
    public float BatteryLevel => _batteryLevel;

    private string _identifier ="-1";
    public string Identifier => _identifier;

    private bool _charging;
    public bool Charging => _charging;

    private float _volume;
    public float Volume => _volume;

    public ClientModel()
    {
        _ip = "";
        _inputEnabled = true;
    }

    public ClientModel SetIp(string ip)
    {
        _ip = ip;
        return this;
    }

    public ClientModel SetInputEnabled(bool enabled)
    {
        _inputEnabled = enabled;
        return this;
    }

    public ClientModel SetCurrentState(string state)
    {
        _currentState = (AppState)Enum.Parse(typeof(AppState), state);
        return this;
    }

    public ClientModel SetBatteryLevel(float batteryLevel)
    {
        _batteryLevel = batteryLevel;
        return this;
    }

    public ClientModel SetIdentifier(string identifier)
    {
        _identifier = identifier;
        return this;
    }

    public ClientModel SetCharging(bool charging)
    {
        _charging = charging;   
        return this;
    }

    public ClientModel SetVolume(float volume)
    {
        _volume = volume;
        return this;
    }
}
