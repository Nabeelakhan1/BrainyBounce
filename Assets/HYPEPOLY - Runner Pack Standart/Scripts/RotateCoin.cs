using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    public float rotationSpeed = 90.0f;

    void Update()
    {
        // Calculate the rotation for this frame
        float rotationY = rotationSpeed * Time.deltaTime;

        // Rotate the object around its Y axis
        transform.Rotate(0, rotationY, 0);
    }
}
