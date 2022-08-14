using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardRotator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RotateLeft()
    {
        transform.rotation = Quaternion.Euler(0f, (transform.rotation.eulerAngles.y - 90f) % 360f, 0f);
    }

    public void RotateRight()
    {
        transform.rotation = Quaternion.Euler(0f, (transform.rotation.eulerAngles.y + 90f) % 360f, 0f);
    }
}