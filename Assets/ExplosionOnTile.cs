using System.Collections;
using System.Collections.Generic;
using Board;
using Tiles;
using Unity.VisualScripting;
using UnityEngine;

public class ExplosionOnTile : MonoBehaviour
{
    public GameObject oneTimeExplosionTemplate;
    public TileSettings tileSettings;

    public void Trigger(int power)
    {
        Instantiate(oneTimeExplosionTemplate, transform.position, Quaternion.identity);
        TriggerInternal(power);
    }

    private void TriggerInternal(int power)
    {
        var tile = GetComponentInParent<TileRoot>();
        tile.ChangeType(TileRoot.TileType.Soil);
        tile.ChangeTileAppearance(tileSettings.soilStyle);

        if (power > 0)
        {
            var tileRepository = GetComponentInParent<TileRepository>();
            var neighbours = tileRepository.neighbourMap[tile.gridPosition];
            foreach (var tileRoot in neighbours)
            {
                tileRoot.DemolishOccupant();
                tileRoot.Build(tileSettings.explosionTemplate);

                var explosion = tileRoot.GetComponentInChildren<ExplosionOnTile>();
                explosion.TriggerInternal(power - 1);
            }
        }

        tile.DemolishOccupant();
    }
}