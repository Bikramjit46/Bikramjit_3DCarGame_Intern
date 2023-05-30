using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowObject : MonoBehaviour
{
    private Transform CameraTarget;
    private Vector3 Offset;
    //[SerializeField] private float smoothTime = 0.3f;
    private Vector3 cameraVelocity = Vector3.zero;

    private void Awake()
    {
        CameraTarget = GameObject.FindGameObjectWithTag("Player").transform;
        Offset = transform.position - CameraTarget.transform.position;
    }

    private void LateUpdate()
    {
        Vector3 targetposition = CameraTarget.transform.position + Offset;

        //transform.position = Vector3.SmoothDamp(transform.position,targetposition,ref cameraVelocity,smoothTime);
        transform.position = targetposition;
        //transform.LookAt(CameraTarget);
    }
}
