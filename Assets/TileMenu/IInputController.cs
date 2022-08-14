using UnityEngine;
using UnityEngine.InputSystem;

namespace TileMenu
{
    public interface IInputController
    {
        public void OnRotate(InputAction.CallbackContext context);

        public void OnClick(InputAction.CallbackContext context);

        public void OnContext(InputAction.CallbackContext context);

        public void OnMove(InputAction.CallbackContext context);

        public void SetPosition(Vector2 position);
        bool CustomRotation { get; }
    }
}