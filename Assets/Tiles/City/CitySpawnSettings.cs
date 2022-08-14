using UnityEngine;

namespace Tiles.City
{
    [CreateAssetMenu(fileName = "CitySpawnSettings", menuName = "CitySpawnSettings", order = 0)]
    public class CitySpawnSettings : ScriptableObject
    {
        public int tileDivisions = 3;

        public GameObject crossingTemplate;
        public GameObject verticalRoadTemplate;
        public GameObject horizontalRoadTemplate;

        public GameObject parkTemplate;
        public GameObject houseTemplate;

        public GameObject RandomTemplate()
        {
            var all = new[]
            {
                crossingTemplate,
                verticalRoadTemplate,
                horizontalRoadTemplate,
                parkTemplate,
                houseTemplate
            };

            return all[Random.Range(0, all.Length)];
        }
    }
}