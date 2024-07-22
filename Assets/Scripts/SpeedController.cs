using Dreamteck.Splines;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpeedController : MonoBehaviour
{
    public SplineFollower splineFollower;
    public float slowdownFactor = 0.5f;
    public float speedupFctor = 2.0f;

    private bool isSlowDown=false;
    private bool isSpeedUp=false;
    public float originalSpeed;
    
    void Start()
    {
        originalSpeed = splineFollower.followSpeed;
       
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            isSlowDown = true;
            AdjustSpeed();
            
        }
        if (Input.GetKeyUp(KeyCode.S)) 
        { 
            isSlowDown= false;
            AdjustSpeed();
        }
        ///////////////////////
        if (Input.GetKeyDown(KeyCode.W))
        {
            isSpeedUp = true;
            AdjustSpeed();
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            isSpeedUp= false;
            AdjustSpeed();
        }
    }
    
    /// //////////////////////
    public void onSlowDownButtonPressed(BaseEventData eventData)
    {
        isSlowDown = true;
        
        AdjustSpeed();

    }
    public void onSlowDownButtonReleased(BaseEventData eventData)
    {
        isSlowDown = false;
        AdjustSpeed();
    }
    public void onSpeedUpButtonPressed(BaseEventData eventData)
    {
        isSpeedUp = true;
        AdjustSpeed();
    }
    public void onSpeedUpButtonReleased( BaseEventData eventData)
    {
        isSpeedUp = false;
        AdjustSpeed();
    }

    private void AdjustSpeed()
    {
        splineFollower.followSpeed = originalSpeed;

        if((isSlowDown))
        {
            splineFollower.followSpeed *= slowdownFactor;
        }
        if(isSpeedUp)
        {
            splineFollower.followSpeed *= speedupFctor;
        }
    }
}