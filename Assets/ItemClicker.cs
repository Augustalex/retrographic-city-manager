using UnityEngine;

public class ItemClicker : MonoBehaviour
{
    public LayerMask layerMask;
    public Camera mainCamera;
    private PickupableItem _holding;
    private Vector3 _groundPosition;

    private void Update()
    {
        if (_holding)
        {
            _holding.UpdatePosition(_groundPosition);
        }
    }

    public void UpdateMousePosition(Vector2 screenPosition)
    {
        var ray = mainCamera.ScreenPointToRay(screenPosition);
        if (Physics.Raycast(ray, out var hit, 1000f, layerMask))
        {
            _groundPosition = hit.point;
        }
    }

    public void CancelHold()
    {
        if (_holding)
        {
            DropItem();
        }
    }

    public bool TrySelectPhysicsItem(Vector2 screenPosition)
    {
        var ray = mainCamera.ScreenPointToRay(screenPosition);

        var tiles = Physics.RaycastAll(ray, 100f);
        foreach (var raycastHit in tiles)
        {
            var item = raycastHit.collider.GetComponentInParent<PickupableItem>();
            if (item)
            {
                PickupItem(item);
                return true;
            }
        }

        return false;
    }

    private void DropItem()
    {
        _holding.Drop();
        _holding = null;
    }

    private void PickupItem(PickupableItem item)
    {
        item.Pickup();
        _holding = item;
    }

    public bool HoldingItem()
    {
        return _holding != null;
    }
}