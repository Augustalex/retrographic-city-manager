using System;
using UnityEngine;

public class TileMenuItem : MonoBehaviour
{
    public event Action<TileRoot> Setup;
    public event Action<TileRoot> Triggered;
    public event Action Closed;

    private TileRoot _activeTile;
    private MeshRenderer _meshRenderer;
    private static readonly int CanTrigger = Shader.PropertyToID("_CanTrigger");
    private bool _enabled;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void Trigger()
    {
        if (!_enabled) return;

        Triggered?.Invoke(_activeTile);
    }

    public void Close()
    {
        Closed?.Invoke();
    }

    public void SetActiveTile(TileRoot tile)
    {
        _activeTile = tile;

        Setup?.Invoke(_activeTile);
    }

    public TileRoot GetTile()
    {
        return _activeTile;
    }

    public void SetEnabled(bool toggled)
    {
        _enabled = toggled;
        _meshRenderer.material.SetFloat(CanTrigger, toggled ? 1f : 0f);
    }
}