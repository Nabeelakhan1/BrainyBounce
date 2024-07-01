using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousRotation : MonoBehaviour
{
    // Rotation speed around each axis
    public float rotationSpeedX = 10f;
    public float rotationSpeedY = 20f;
    public float rotationSpeedZ = 30f;

    void Update()
    {
        // Calculate rotation for each frame
        float rotationX = rotationSpeedX * Time.deltaTime;
        float rotationY = rotationSpeedY * Time.deltaTime;
        float rotationZ = rotationSpeedZ * Time.deltaTime;

        // Apply the rotation to the transform
        transform.Rotate(rotationX, rotationY, rotationZ);
    }
}
