using System;
using UnityEngine;

public class Diskette : MonoBehaviour
{
    private PickupableItem _pickupable;
    private FloppyHole _hole;
    private float _lastEjected;

    public event Action<FloppyHole> Activated;
    public event Action Deactivated;

    void Awake()
    {
        _pickupable = GetComponent<PickupableItem>();

        _pickupable.PickedUp += Eject;
        _pickupable.Unstationed += Eject;
    }

    void Update()
    {
        if (Time.time - _lastEjected < .25f) return;

        foreach (var hit in Physics.OverlapSphere(transform.position, .1f))
        {
            var hole = hit.GetComponent<FloppyHole>();
            if (hole && !hole.Occupied())
            {
                Insert(hole);
            }
        }
    }

    private void Insert(FloppyHole hole)
    {
        transform.position = hole.transform.position;
        _pickupable.Stationary();

        _hole = hole;
        hole.Insert();

        Activated?.Invoke(hole);
    }

    private void Eject()
    {
        if (_hole)
        {
            _lastEjected = Time.time;
            _hole.Eject();
            Deactivated?.Invoke();
        }
    }
}