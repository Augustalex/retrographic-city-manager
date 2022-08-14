using System;
using TileMenu;
using UnityEngine;

public class FloppyHole : MonoBehaviour
{
    public GamePlayerInputManager inputManager;

    public event Action Inserted;
    public event Action Ejected;
    
    private bool _occupied;

    public void InstallController(IInputController inputController)
    {
        inputManager.InstallInputController(inputController);
    }

    public void Insert()
    {
        _occupied = true;
        Inserted?.Invoke();
    }

    public void Eject()
    {
        _occupied = false;
        inputManager.ResetInputController();
        Ejected?.Invoke();
    }

    public bool Occupied()
    {
        return _occupied;
    }
}