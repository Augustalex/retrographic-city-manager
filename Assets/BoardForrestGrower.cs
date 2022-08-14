using System.Collections;
using System.Collections.Generic;
using Board;
using Tiles;
using UnityEngine;

public class BoardForrestGrower : MonoBehaviour
{
    public TileSettings tileSettings;
    private TileRepository _tileRepository;
    private Coroutine _routine;
    private float _delta = .25f;

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
            yield return new WaitForSeconds(_delta);
            foreach (var tileRoot in _tileRepository.tiles)
            {
                var neighbours = _tileRepository.neighbourMap[tileRoot.gridPosition];

                if (tileRoot.tileType == TileRoot.TileType.Grass && tileRoot.CanBuild())
                {
                    var water = 0;
                    var forrest = 0;
                    foreach (var neighbour in neighbours)
                    {
                        if (neighbour.tileType == TileRoot.TileType.Water) water += 1;
                        else if (neighbour.GetComponentInChildren<GreenTileScenary>()) forrest += 1;
                    }

                    if (water > 1 || forrest > 1)
                    {
                        if (Random.value < .08f * _delta)
                        {
                            tileRoot.Build(tileSettings.treeTemplate);
                        }
                    }
                }
            }
        }
    }
}