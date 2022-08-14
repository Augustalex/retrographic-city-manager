using UnityEngine;

public class TileRoot : MonoBehaviour
{
    private GameObject _occupied;

    public Vector2 gridPosition;

    public enum TileType
    {
        Soil,
        Water,
        Grass
    }

    public enum TileModifier
    {
        Radiation
    }

    public TileType tileType = TileType.Soil;
    public Material currentStyle;

    public void OnRightClick()
    {
        // var greens = GetComponent<GreenTileScenary>();
        // if (greens)
        // {
        //     greens.CycleTrees();
        // }
    }

    public void Build(GameObject template)
    {
        _occupied = Instantiate(template, transform.position, Quaternion.identity, transform);
    }

    public bool CanBuild()
    {
        return _occupied == null;
    }

    public void ChangeType(TileType type)
    {
        tileType = type;
    }

    public void ChangeTileAppearance(Material style)
    {
        currentStyle = style;
        GetComponentInChildren<MeshRenderer>().materials = new[] {style};
    }

    public void DemolishOccupant()
    {
        Destroy(_occupied);
    }
}