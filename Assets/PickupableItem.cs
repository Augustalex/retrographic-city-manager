using System;
using UnityEngine;

public class PickupableItem : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public event Action PickedUp;
    public event Action Dropped;
    public event Action Stationed;
    public event Action Unstationed;

    public enum PickupStatus
    {
        Dropped,
        PickedUp,
        Stationary
    };

    public PickupStatus status = PickupStatus.Dropped;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Drop()
    {
        if (status == PickupStatus.Stationary) return;

        _rigidbody.isKinematic = false;

        status = PickupStatus.Dropped;
        Dropped?.Invoke();
    }

    public void Pickup()
    {
        _rigidbody.isKinematic = true;
        transform.rotation = Quaternion.identity;

        if (status == PickupStatus.Stationary)
        {
            Unstationed?.Invoke();
        }

        status = PickupStatus.PickedUp;
        PickedUp?.Invoke();
    }

    public void UpdatePosition(Vector3 groundPosition)
    {
        if (status == PickupStatus.PickedUp)
        {
            _rigidbody.position = groundPosition + Vector3.up * .125f;
        }
    }

    public void Stationary()
    {
        status = PickupStatus.Stationary;
        _rigidbody.isKinematic = true;

        Stationed?.Invoke();
    }
}