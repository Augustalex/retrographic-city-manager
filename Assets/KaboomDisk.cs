using TileMenu;
using Tiles;
using UnityEngine;
using UnityEngine.InputSystem;

public class KaboomDisk : MonoBehaviour, IInputController
{
    public TileSettings tileSettings;
    public BoardClicker boardClicker;
    private Diskette _disk;
    private Vector2 _position;

    void Awake()
    {
        _disk = GetComponent<Diskette>();

        _disk.Activated += Install;
    }

    private void Install(FloppyHole hole)
    {
        hole.InstallController(this);
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        // Unused 
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            var tile = boardClicker.SelectedTile(_position);
            if (tile)
            {
                tile.DemolishOccupant();
                tile.Build(tileSettings.explosionTemplate);

                var explosion = tile.GetComponentInChildren<ExplosionOnTile>();
                explosion.Trigger(3);
            }
        }
    }

    public void OnContext(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            var tile = boardClicker.SelectedTile(_position);
            if (tile)
            {
                tile.DemolishOccupant();
                tile.Build(tileSettings.explosionTemplate);
            }
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // Unused
    }

    public void SetPosition(Vector2 position)
    {
        _position = position;
    }

    public bool CustomRotation => false;
}