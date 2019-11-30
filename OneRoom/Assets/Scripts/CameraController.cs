using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [Header("Target variables")]
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float targetOffset = 10.0f;

    [Header("Speed limits")]
    [SerializeField] private float minSpeed = -35.0f;
    [SerializeField] private float maxSpeed = 35.0f;
    private float speed = 0.0f;


    private void Awake()
    {
        if(targetTransform)
            transform.position = targetTransform.position - Vector3.forward * targetOffset;
    }

    private void Update()
    {
        speed += Input.GetAxis("Horizontal");
        speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
    }

    private void FixedUpdate()
    {
        if(targetTransform)
            transform.RotateAround(targetTransform.position, -Vector3.up, speed * Time.deltaTime);
    }
}
