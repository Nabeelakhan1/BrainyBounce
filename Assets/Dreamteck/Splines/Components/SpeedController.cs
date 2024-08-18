using Dreamteck.Splines;
using UnityEngine;
using UnityEngine.EventSystems; // Include this for BaseEventData

public class SpeedController : MonoBehaviour
{
    public SplineFollower splineFollower; // Reference to the SplineFollower
    public float slowdownFactor = 0.5f; // Factor by which to slow down the speed

    private bool isSlowedDown = false;

    void Update()
    {
        // Check for slowdown input
        if (Input.GetKeyDown(KeyCode.S)) // Replace KeyCode.S with the desired key
        {
            isSlowedDown = true;
            AdjustSpeed();
        }
        if (Input.GetKeyUp(KeyCode.S)) // Replace KeyCode.S with the desired key
        {
            isSlowedDown = false;
            AdjustSpeed();
        }
    }

    // Method to be called on pointer down event
    public void OnSlowDownButtonPressed(BaseEventData eventData) // Add BaseEventData parameter
    {
        isSlowedDown = true;
        AdjustSpeed();
    }

    // Method to be called on pointer up event
    public void OnSlowDownButtonReleased(BaseEventData eventData) // Add BaseEventData parameter
    {
        isSlowedDown = false;
        AdjustSpeed();
    }

    private void AdjustSpeed()
    {
        if (isSlowedDown)
        {
            splineFollower.followSpeed *= slowdownFactor;
        }
        else
        {
            splineFollower.followSpeed /= slowdownFactor;
        }
    }
}
