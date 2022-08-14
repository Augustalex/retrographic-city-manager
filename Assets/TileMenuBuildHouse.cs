using Tiles;
using UnityEngine;

[RequireComponent(typeof(TileMenuItem))]
public class TileMenuBuildHouse : MonoBehaviour
{
    public TileSettings tileSettings;
    private TileMenuItem _tileMenuItem;

    void Awake()
    {
        _tileMenuItem = GetComponent<TileMenuItem>();
        _tileMenuItem.Triggered += BuildHouse;
        _tileMenuItem.Setup += Setup;
    }

    private void Setup(TileRoot tile)
    {
        _tileMenuItem.SetEnabled(tile.CanBuild());
    }

    private void BuildHouse(TileRoot tile)
    {
        tile.Build(tileSettings.houseTile);
        _tileMenuItem.Close();
    }
}