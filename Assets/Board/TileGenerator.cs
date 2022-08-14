using Tiles;
using UnityEngine;

namespace Board
{
    public class TileGenerator : MonoBehaviour
    {
        public TileRepository tileRepository;
        public TileSettings tileSettings;

        void Awake()
        {
            var halfExtends = transform.localScale * .5f;
            var halfExtendsFlat = new Vector3(halfExtends.x, 0f, halfExtends.z);

            for (int x = 0; x < tileSettings.tilesX; x++)
            {
                for (int y = 0; y < tileSettings.tilesY; y++)
                {
                    var template = tileSettings.tileTemplate;
                    var centerOffset = new Vector3(template.transform.localScale.x * .5f, 0f,
                        template.transform.localScale.z * .5f);
                    var tilePosition = (new Vector3(x, 0f, y) + centerOffset) * tileSettings.tileScale;
                    var position = transform.position + tilePosition;

                    var tile = Instantiate(template,
                        position - halfExtendsFlat,
                        Quaternion.identity, transform);
                    tile.transform.localScale = Vector3.one * tileSettings.tileScale;
                    var gridPosition = new Vector2(x, y);
                    tile.GetComponent<TileRoot>().gridPosition = gridPosition;
                    tileRepository.Register(tile, gridPosition);
                }
            }

            transform.localScale = Vector3.one * .98f;

            tileRepository.Lock();
        }
    }
}