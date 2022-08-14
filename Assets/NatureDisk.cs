using System.Collections;
using System.Collections.Generic;
using TileMenu;
using Tiles;
using UnityEngine;
using UnityEngine.InputSystem;

public class NatureDisk : MonoBehaviour, IInputController
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
                if (tile.CanBuild())
                {
                    tile.ChangeType(TileRoot.TileType.Grass);
                    tile.ChangeTileAppearance(tileSettings.grassStyle);

                    // if (tile.tileType == TileRoot.TileType.Grass)
                    // {
                    //     tile.Build(tileSettings.treeTemplate);
                    // }
                    // else if (tile.tileType == TileRoot.TileType.Water)
                    // {
                    //     // TODO: Build fish
                    // }
                }
            }
        }
    }

    public void OnContext(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            var tile = boardClicker.SelectedTile(_position);
            if (tile && !tile.CanBuild())
            {
                tile.DemolishOccupant();
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