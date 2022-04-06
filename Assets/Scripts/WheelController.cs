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



    [SerializeField] Transform steeringWheel;
    [SerializeField] Animator steeringWheelAnimation;
    public float acceleration = 6000f;
    public float breakingForce = 300f;
    public float maxTurnAngle = 15f;

    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0f;

    public bool isPlayerRide;
    public bool isEngineStart;
    
    [Header("Sound Effects")]
    public AudioSource engineStart;
    public audio EngineAudio;
    

    private void Start()
    {
        EngineAudio = GetComponent<audio>();
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.H))
        {

            EngineAudio.PlayHorn();

        }

        if (Input.GetKeyUp(KeyCode.H))
        {
            EngineAudio.StopHorn();


        }
    }
    private void FixedUpdate()
    {
        // steeringWheel.localEulerAngles = Vector3.back * Mathf.Clamp((Input.GetAxis("Horizontal") * 100), -maxTurnAngle, maxTurnAngle);

       /// Debug.Log("Ishorning: "+isHorn);
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isPlayerRide)
            {
                isPlayerRide = true;
            }

           
        }

        if (isPlayerRide)
        {

            if (!isEngineStart)
            {

                engineStart.Play();
                isEngineStart = true;
            }
            currentAcceleration = acceleration * (Input.GetAxis("Vertical") * 1f);
            


            //
            if (Input.GetKey(KeyCode.Space))
            {
                currentBreakForce = breakingForce;
                EngineAudio.PlayHandBrake();
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


            steeringWheelAnimation.SetFloat("steer", Input.GetAxis("Horizontal"));
           // Debug.Log("currentAcceleration: " + currentAcceleration);
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
