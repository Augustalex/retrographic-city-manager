using Tiles;
using Tiles.City;
using UnityEngine;

public class HouseSpawn : MonoBehaviour
{
    public TileSettings tileSettings;
    public CitySpawnSettings citySpawnSettings;

    void Start()
    {
        for (int x = 0; x < citySpawnSettings.tileDivisions; x++)
        {
            for (int y = 0; y < citySpawnSettings.tileDivisions; y++)
            {
                var miniTileSize = 1f / citySpawnSettings.tileDivisions;
                var offset = new Vector3(
                    x * miniTileSize,
                    0f,
                    y * miniTileSize
                );
                var position =
                    transform.position +
                    offset; // - new Vector3(tileSettings.tileScale * .5f, 0f, tileSettings.tileScale * .5f);
                GameObject template = citySpawnSettings.RandomTemplate();
                var obj = Instantiate(template);
                obj.transform.SetParent(transform);
                obj.transform.localPosition = new Vector3(-.5f, 0f, -.5f) +
                                              new Vector3(
                                                  (1f / (citySpawnSettings.tileDivisions * 2f)),
                                                  0f,
                                                  (1f / (citySpawnSettings.tileDivisions * 2f))) +
                                              new Vector3(x, 0f, y) / citySpawnSettings.tileDivisions;
                obj.transform.localScale = Vector3.one / citySpawnSettings.tileDivisions;
            }
        }
    }
}