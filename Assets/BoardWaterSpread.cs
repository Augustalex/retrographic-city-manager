using System.Collections;
using Board;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardWaterSpread : MonoBehaviour
{
    private TileRepository _tileRepository;
    private Coroutine _routine;

    private const float Delta = .75f;

    void Awake()
    {
        _tileRepository = GetComponent<TileRepository>();
    }

    private void OnEnable()
    {
        if (_routine != null) StopCoroutine(_routine);
        _routine = StartCoroutine(Cycle());
    }

    private void OnDisable()
    {
        StopCoroutine(_routine);
        _routine = null;
    }

    IEnumerator Cycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(Delta);
            foreach (var tileRoot in _tileRepository.tiles)
            {
                var neighbours = _tileRepository.neighbourMap[tileRoot.gridPosition];

                if (tileRoot.tileType == TileRoot.TileType.Water)
                {
                    foreach (var neighbour in neighbours)
                    {
                        if (Random.value > .3f) continue;

                        if (neighbour.tileType == TileRoot.TileType.Soil)
                        {
                            neighbour.ChangeType(TileRoot.TileType.Water);
                            neighbour.ChangeTileAppearance(tileRoot.currentStyle);
                        }
                    }
                }
            }
        }
    }
}