using TileMenu;
using Tiles;
using UnityEngine;
using UnityEngine.InputSystem;

public class TerraformDisk : MonoBehaviour, IInputController
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
                tile.ChangeType(TileRoot.TileType.Water);
                tile.ChangeTileAppearance(tileSettings.waterStyle);
                // tile.ChangeType(TileRoot.TileType.Grass);
                // tile.ChangeTileAppearance(tileSettings.grassStyle);
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
                tile.ChangeType(TileRoot.TileType.Water);
                tile.ChangeTileAppearance(tileSettings.waterStyle);
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