using UnityEngine;

namespace Tiles
{
    [CreateAssetMenu(fileName = "TileSettings", menuName = "TileSettings", order = 0)]
    public class TileSettings : ScriptableObject
    {
        public GameObject houseTile;
        public GameObject treeTemplate;
        public GameObject explosionTemplate;
        public GameObject tileTemplate;
        public Material grassStyle;
        public Material waterStyle;
        public Material soilStyle;
        
        public float tileScale = 1f;
        public int tilesX = 10;
        public int tilesY = 10;
    }
}