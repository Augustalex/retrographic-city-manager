using System;
using TileMenu;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuInputController : MonoBehaviour, IInputController
{
    public BoardClicker boardClicker;
    public MenuController menuController;

    public event Action Dismissed;

    private Vector2 _position;
    private TileRoot _activeTile;

    void Start()
    {
        menuController.Hide();

        menuController.Closed += Dismiss;
    }

    public void Show(TileRoot tileRoot)
    {
        _activeTile = tileRoot;
        menuController.ShowAt(tileRoot);
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            menuController.ClickAt(_position);

            // var tile = boardClicker.SelectedTile(_position);
            // if (tile)
            // {
            //     Show(tile);
            // }
            // else
            // {
            //     Dismiss();
            // }
        }
    }

    public void OnContext(InputAction.CallbackContext context)
    {
        Dismiss();
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

    private void Dismiss()
    {
        menuController.Hide();
        Dismissed?.Invoke();
    }
}