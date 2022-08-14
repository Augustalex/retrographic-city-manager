using System;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public Camera boardCamera;
    public GameObject menuRoot;
    private TileRoot _currentTile;
    private TileMenuItem[] _icons;

    public event Action Closed;

    public void ShowAt(TileRoot tile)
    {
        menuRoot.SetActive(true);
        menuRoot.transform.position = tile.transform.position + Vector3.up * .25f;

        _currentTile = tile;

        Debug.Log("SHOW AT");
        _icons = menuRoot.GetComponentsInChildren<TileMenuItem>();
        foreach (var tileMenuItem in _icons)
        {
            tileMenuItem.SetActiveTile(tile);
            tileMenuItem.Closed += Close;
        }
    }

    public bool IsVisible()
    {
        return menuRoot.activeSelf;
    }

    public void Hide()
    {
        menuRoot.SetActive(false);
    }

    public void ClickAt(Vector2 screenPosition)
    {
        var ray = boardCamera.ScreenPointToRay(screenPosition);

        var tiles = Physics.RaycastAll(ray, 100f);
        foreach (var raycastHit in tiles)
        {
            var item = raycastHit.collider.GetComponent<TileMenuItem>();
            if (item)
            {
                item.Trigger();
            }
        }
    }

    private void Close()
    {
        foreach (var tileMenuItem in _icons)
        {
            tileMenuItem.Closed -= Close;
        }

        Hide();
        Closed?.Invoke();
    }
}