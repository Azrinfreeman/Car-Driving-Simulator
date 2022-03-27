using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;

    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backRightTransform;
    [SerializeField] Transform backLeftTransform;

    public float acceleration = 6000f;
    public float breakingForce = 300f;
    public float maxTurnAngle = 15f;

    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0f;

    public bool isPlayerRide;
    public bool isEngineStart;
    public AudioSource engineStart;
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
        }

        if (isPlayerRide)
        {

            if (isEngineStart)
            {

                engineStart.Play();
                isEngineStart = false;
            }
            currentAcceleration = acceleration * (Input.GetAxis("Vertical") * 1f);
            //
            if (Input.GetKey(KeyCode.Space))
            {
                currentBreakForce = breakingForce;
            }
            else
            {
                currentBreakForce = 0f;
            }
            //To apply acceleration on the front wheels
            frontRight.motorTorque = currentAcceleration;
            frontLeft.motorTorque = currentAcceleration;
            //backLeft.motorTorque = currentAcceleration;
            //backRight.motorTorque = currentAcceleration;

            frontRight.brakeTorque = currentBreakForce;
            frontLeft.brakeTorque = currentBreakForce;
            backRight.brakeTorque = currentBreakForce;
            backLeft.brakeTorque = currentBreakForce;

            //turning

            currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
            frontLeft.steerAngle = currentTurnAngle;
            frontRight.steerAngle = currentTurnAngle;

            UpdateWheel(frontLeft, frontLeftTransform);
            UpdateWheel(frontRight, frontRightTransform);
            UpdateWheel(backLeft, backLeftTransform);
            UpdateWheel(backRight, backRightTransform);

            Debug.Log("currentAcceleration: " + currentAcceleration);
        }

       
    }
    
    void UpdateWheel(WheelCollider col, Transform trans)
    {

        //Get Wheel collider state
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;
    }

}
