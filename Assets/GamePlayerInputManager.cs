using TileMenu;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(MainInputController))]
[RequireComponent(typeof(MenuInputController))]
public class GamePlayerInputManager : MonoBehaviour
{
    public ItemClicker itemClicker;

    private Vector2 _position;
    private MainInputController _mainInputController;
    private MenuInputController _menuInputController;
    private IInputController _currentController;
    private bool _customControllerActive;

    public void OnRotate(InputAction.CallbackContext context)
    {
        if (_currentController.CustomRotation)
        {
            _currentController.OnRotate(context);
        }
        else
        {
            _mainInputController.OnRotate(context);
        }
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (itemClicker.TrySelectPhysicsItem(_position)) return;
        }

        if (context.canceled)
        {
            itemClicker.CancelHold();
        }

        _currentController.OnClick(context);
    }

    public void OnContext(InputAction.CallbackContext context)
    {
        _currentController.OnContext(context);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _position = context.ReadValue<Vector2>();
        itemClicker.UpdateMousePosition(_position);

        _mainInputController.SetPosition(_position);
        _menuInputController.SetPosition(_position);
        _currentController.SetPosition(_position);

        _currentController.OnMove(context);
    }

    private void Awake()
    {
        _menuInputController = GetComponent<MenuInputController>();

        _mainInputController = GetComponent<MainInputController>();
        _mainInputController.ToggleMenu += (tile) =>
        {
            _menuInputController.Show(tile);
            _currentController = _menuInputController;
        };

        _menuInputController.Dismissed += () => { _currentController = _mainInputController; };

        _currentController = _mainInputController;
    }

    public void InstallInputController(IInputController inputController)
    {
        _currentController = inputController;
        _customControllerActive = true;
    }

    public void ResetInputController()
    {
        _customControllerActive = false;
        _currentController = _mainInputController;
    }
}