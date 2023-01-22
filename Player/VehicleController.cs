using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    [Header("Wheels Collider")]
    public WheelCollider frontRightWheelCollider;
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider backRightWheelCollider;
    public WheelCollider backLeftWheelCollider;

    [Header("Wheels Transform")]
    public Transform frontRightWheelTransform;
    public Transform frontLeftWheelTransform;
    public Transform backRightWheelTransform;
    public Transform backLeftWheelTransform;
    public Transform VehicleDoor;

    [Header("Wheel Engine")]
    public float accelerationForce = 100f;
    private float presentAcceleration = 0f;
    public float breakingForce = 200f;
    private float presentBreakingForce = 0f;
    public GameObject CarCamera;

    [Header("Vehicle Steering")]
    public float wheelsTorque = 20f;
    private float presentTurnAngle = 0f;

    [Header("Vehicle Security")]
    public PlayerScript player;
    private float radius = 3f;
    private bool isOpened = false;

    [Header("Vehicle Disable")]
    public GameObject AimCam;
    public GameObject crossHair;
    public GameObject ThirdPersonCam;
    public GameObject PlayerCharacter;

    private void Update() {
        if(Vector3.Distance(transform.position, player.transform.position) < radius) {
            if(Input.GetKeyDown(KeyCode.F)) {
                isOpened = true;
                radius = 5000f;
                PlayerCharacter.SetActive(false);
            }
            else if(Input.GetKeyDown(KeyCode.G)) {
                player.transform.position = VehicleDoor.transform.position;
                isOpened = false;
                radius = 5f;
                PlayerCharacter.SetActive(true);
            }
        }

        if(isOpened == true) {
            ThirdPersonCam.SetActive(false);
            AimCam.SetActive(false);
            crossHair.SetActive(false);
            CarCamera.SetActive(true);

            MoveVehicle();
            VehicleSteering();
            ApplyBreaks();
        }
        else if(isOpened == false) {
            ThirdPersonCam.SetActive(true);
            AimCam.SetActive(true);
            crossHair.SetActive(true);
            CarCamera.SetActive(false);
        } 
    }

    void MoveVehicle() {
        frontRightWheelCollider.motorTorque = presentAcceleration;
        frontLeftWheelCollider.motorTorque = presentAcceleration;
        backRightWheelCollider.motorTorque = presentAcceleration;
        backLeftWheelCollider.motorTorque = presentAcceleration;

        presentAcceleration = accelerationForce * Input.GetAxis("Vertical");

    }

    void VehicleSteering() {
        presentTurnAngle = wheelsTorque * Input.GetAxis("Horizontal");
        frontRightWheelCollider.steerAngle = presentTurnAngle;
        frontLeftWheelCollider.steerAngle = presentTurnAngle;
        SteeringWheels(frontRightWheelCollider, frontRightWheelTransform);
        SteeringWheels(frontLeftWheelCollider, frontLeftWheelTransform);
        SteeringWheels(backRightWheelCollider, backRightWheelTransform);
        SteeringWheels(backLeftWheelCollider, backLeftWheelTransform);
    }

    void SteeringWheels(WheelCollider WC, Transform WT) {
        Vector3 position;
        Quaternion rotation;

        WC.GetWorldPose(out position, out rotation);
        WT.position = position;
        WT.rotation = rotation;
    }

    void ApplyBreaks() {
        if(Input.GetKey(KeyCode.Space)) {
            presentBreakingForce = breakingForce;
        }
        else {
            presentBreakingForce = 0f;
        }

        frontRightWheelCollider.brakeTorque = presentBreakingForce;
        frontLeftWheelCollider.brakeTorque = presentBreakingForce;
        backRightWheelCollider.brakeTorque = presentBreakingForce;
        backLeftWheelCollider.brakeTorque = presentBreakingForce;
    }
}
