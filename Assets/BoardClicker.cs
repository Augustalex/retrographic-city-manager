using System;
using System.Collections;
using System.Collections.Generic;
using Board;
using UnityEngine;

public class BoardClicker : MonoBehaviour
{
    public Camera boardCamera;
    public TileRepository tileRepository;

    public TileRoot SelectedTile(Vector3 screenPosition)
    {
        var ray = boardCamera.ScreenPointToRay(screenPosition);

        var tiles = Physics.RaycastAll(ray, 100f);
        foreach (var raycastHit in tiles)
        {
            var tile = raycastHit.collider.GetComponentInParent<TileRoot>();
            if (tile)
            {
                return tile;
            }
        }

        return null;
    }

    public void RightClickAt(Vector2 screenPosition)
    {
        var ray = boardCamera.ScreenPointToRay(screenPosition);

        var tiles = Physics.RaycastAll(ray, 100f);
        foreach (var raycastHit in tiles)
        {
            var tile = raycastHit.collider.GetComponentInParent<TileRoot>();
            if (tile)
            {
                tile.OnRightClick();
            }
        }
    }
}