using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController PlayerController;
    Animator PlayerAnimator;
    private float PlayerMovementSpeed = 2;
    [SerializeField] GameObject PlayerObject;
    [SerializeField] float RunningSpeed = 3.6f;
    [SerializeField] float WalkingSpeed = 2f;
    [SerializeField] float RotationSpeed = 720;
    private bool IsSprintingButtonPressed = false;
    Vector3 PlayerDirection;

    //float rotationfactorperframe = 1.0f;


    void Update()
    {
        HandleMovement();
        
        HandleAnimation();
        
        HandleSprinting();


        if (PlayerDirection != Vector3.zero)
        {
            HandleRotation();
        }

        
    }
    private void Awake()
    {
        PlayerController = GetComponent<CharacterController>();
        //PlayerAnimator = GetComponent<Animator>();
        PlayerAnimator = PlayerObject.GetComponent<Animator>();
        PlayerMovementSpeed = WalkingSpeed;

    }

    private void HandleMovement()
    {
        float ForwardVector = Input.GetAxis("Vertical");
        float RightVector = Input.GetAxis("Horizontal");

        PlayerDirection = new Vector3(RightVector, 0, ForwardVector);

        PlayerController.Move((PlayerDirection.normalized) * Time.deltaTime * PlayerMovementSpeed);
        //transform.Translate(PlayerDirection * PlayerMovementSpeed * Time.deltaTime, Space.World);
    }
    private void HandleAnimation()
    {
        float Playervelocity = PlayerController.velocity.magnitude;
        if (Playervelocity > 0 && IsSprintingButtonPressed == false)
        {
            PlayerAnimator.SetBool("IsWalking", true);
        }

        else
        {
            PlayerAnimator.SetBool("IsWalking", false);
        }

    }

    private void HandleRotation()
    {
        Quaternion toRotation = Quaternion.LookRotation(PlayerDirection, Vector3.up);
        this.transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, RotationSpeed * Time.deltaTime);
    }
    private void HandleSprinting()
    {
        IsSprintingButtonPressed = Input.GetKey(KeyCode.LeftShift);

        if (IsSprintingButtonPressed)
        {
            PlayerMovementSpeed = RunningSpeed;
            PlayerAnimator.SetBool("IsRunning", true);
            //Debug.Log("IsSprinting");
        }
        else
        {
            PlayerMovementSpeed = WalkingSpeed;
            PlayerAnimator.SetBool("IsRunning", false);

        }
    }
}
