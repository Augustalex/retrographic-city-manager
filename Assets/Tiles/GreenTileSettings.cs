using UnityEngine;

namespace Tiles
{
    [CreateAssetMenu(fileName = "GreenTileScenery", menuName = "GreenTileScenery", order = 0)]
    public class GreenTileSettings : ScriptableObject
    {
        public GameObject[] treeTemplates;

        public GameObject RandomTree()
        {
            return treeTemplates[Random.Range(0, treeTemplates.Length)];
        }
    }
}