using System.Collections.Generic;
using System.Linq;
using Tiles;
using UnityEngine;

namespace Board
{
    public class TileRepository : MonoBehaviour
    {
        public TileSettings tileSettings;

        private readonly Dictionary<Vector2, GameObject> _grid = new Dictionary<Vector2, GameObject>();

        public TileRoot[] tiles = new TileRoot[] { };
        public readonly Dictionary<Vector2, TileRoot[]> neighbourMap = new Dictionary<Vector2, TileRoot[]>();

        public void Register(GameObject tile, Vector2 gridPosition)
        {
            _grid.Add(gridPosition, tile);
        }

        public void Lock()
        {
            tiles = _grid.Values.Select(c => c.GetComponent<TileRoot>()).ToArray();

            for (int x = 0; x < tileSettings.tilesX; x++)
            {
                for (int y = 0; y < tileSettings.tilesY; y++)
                {
                    var position = new Vector2(x, y);
                    var offsets = Neighbours(position);

                    var neighbours = new List<TileRoot>();
                    foreach (var offset in offsets)
                    {
                        if (_grid.ContainsKey(offset))
                        {
                            neighbours.Add(_grid[offset].GetComponent<TileRoot>());
                        }
                    }

                    neighbourMap[position] = neighbours.ToArray();
                }
            }
            
        }

        private Vector2[] Neighbours(Vector2 origin)
        {
            return new[]
            {
                origin + new Vector2(-1f, -1f),
                origin + new Vector2(0f, -1f),
                origin + new Vector2(1f, -1f),
                origin + new Vector2(-1f, 0f),
                origin + new Vector2(1f, 0f),
                origin + new Vector2(-1f, 1f),
                origin + new Vector2(0f, 1f),
                origin + new Vector2(1f, 1f),
            };
        }

        public bool TryGet(Vector2 gridPosition, out GameObject tile)
        {
            return _grid.TryGetValue(gridPosition, out tile);
        }
    }
}