using Tiles;
using UnityEngine;

public class TileMenuBuildTree : MonoBehaviour
{
    public TileSettings tileSettings;
    private TileMenuItem _tileMenuItem;

    void Start()
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
        tile.Build(tileSettings.treeTemplate);
        _tileMenuItem.Close();
    }
}
