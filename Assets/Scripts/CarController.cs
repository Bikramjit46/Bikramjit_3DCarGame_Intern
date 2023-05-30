using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private bool IsBreaking;
    private float ForwardInput;
    private float RightInput;
    private float CurrentBreakForce;
    private float CurrentSteeringAngle;


    [SerializeField] private WheelCollider FrontLeftWheelCollider, FrontRightWheelCollider, BackLeftWheelCollider, BackRightWheelCollider;
    [SerializeField] private Transform FrontLeftWheelTransform, FrontRightWheelTransform, BackLeftWheelTransform, BackRightWheelTransform;

    [SerializeField] private float MotorForce;
    [SerializeField] private float BreakForce;
    [SerializeField] private float MaxSteeringAngle;



    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        print(CurrentBreakForce);
        //Debug.Log(ForwardInput);

    }

    private void HandleSteering()
    {
        CurrentSteeringAngle = MaxSteeringAngle * RightInput;
        FrontLeftWheelCollider.steerAngle = CurrentSteeringAngle;
        FrontRightWheelCollider.steerAngle = CurrentSteeringAngle;
    }

    private void HandleMotor()
    {
        FrontLeftWheelCollider.motorTorque = ForwardInput * MotorForce;
        FrontRightWheelCollider.motorTorque = ForwardInput * MotorForce;

        //if (IsBreaking)
        //{
        //CurrentBreakForce = BreakForce;
        //ApplyBreaking();

        //}
        //else
        //{
        //    CurrentBreakForce = 0;
        //}
        //CurrentBreakForce = IsBreaking ? BreakForce : 0f;
        //if (IsBreaking)
        //{
        //    ApplyBreaking();
        //}
    }

    private void ApplyBreaking()
    {
        FrontLeftWheelCollider.brakeTorque = CurrentBreakForce;
        FrontRightWheelCollider.brakeTorque = CurrentBreakForce;
        BackLeftWheelCollider.brakeTorque = CurrentBreakForce;
        BackRightWheelCollider.brakeTorque = CurrentBreakForce;
        
    }

    private void GetInput()
    {
        ForwardInput = Input.GetAxis("Vertical");
        RightInput = Input.GetAxis("Horizontal");
        IsBreaking = Input.GetKey(KeyCode.Space);

    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(FrontLeftWheelCollider, FrontLeftWheelTransform);
        UpdateSingleWheel(FrontRightWheelCollider, FrontRightWheelTransform);
        UpdateSingleWheel(BackLeftWheelCollider, BackLeftWheelTransform);
        UpdateSingleWheel(BackRightWheelCollider, BackRightWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider,Transform WheelTransform)
    {
        Vector3 pos;
        Quaternion rot;

        wheelCollider.GetWorldPose(out pos, out rot);
        WheelTransform.rotation = rot;
        WheelTransform.position = pos;
    }

}
