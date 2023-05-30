using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject Target = null;
    [SerializeField] private GameObject T = null;

    [SerializeField] private float Speed = 1.5f;

    public int index;

    private void Start()
    {
        //Target = GameObject.FindGameObjectWithTag("Player");
        
    }

    private void FixedUpdate()
    {
        this.transform.LookAt(Target.transform);
        float CarMove = Mathf.Abs(Vector3.Distance(this.transform.position, T.transform.position) * Speed);
        this.transform.position = Vector3.MoveTowards(this.transform.position,T.transform.position,CarMove*Time.deltaTime);
    }


}
