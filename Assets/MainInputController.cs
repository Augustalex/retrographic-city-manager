using System;
using TileMenu;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainInputController : MonoBehaviour, IInputController
{
    public ItemClicker itemClicker;
    public BoardRotator boardRotator;
    public BoardClicker boardClicker;
    private Vector3 _position;

    public event Action<TileRoot> ToggleMenu;

    public void OnRotate(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            var rotation = context.ReadValue<float>();
            if (rotation < 0) boardRotator.RotateLeft();
            else boardRotator.RotateRight();
        }
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        return;
        
        // TODO: Move to diskette
        // if (context.performed && !itemClicker.HoldingItem())
        // {
        //     var tile = boardClicker.SelectedTile(_position);
        //     if (tile)
        //     {
        //         ToggleMenu?.Invoke(tile);
        //     }
        // }
    }

    public void OnContext(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            boardClicker.RightClickAt(_position);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _position = context.ReadValue<Vector2>();
    }

    public void SetPosition(Vector2 position)
    {
        _position = position;
    }

    public bool CustomRotation => true;
}