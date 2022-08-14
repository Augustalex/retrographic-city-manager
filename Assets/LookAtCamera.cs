using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Camera targetCamera;

    void Update()
    {
        var currentRotation = transform.rotation.eulerAngles;
        transform.LookAt(targetCamera.transform.position);
        var newRotation = transform.rotation.eulerAngles;

        transform.rotation = Quaternion.Euler(newRotation.x, currentRotation.y, currentRotation.z);
    }
}