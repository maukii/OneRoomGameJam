using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Target variables")]
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float targetOffset = 10.0f;
    [SerializeField] private float speed = 35.0f;
    private float input = 0.0f;


    private void Awake()
    {
        if(targetTransform)
            transform.position = targetTransform.position - Vector3.forward * targetOffset;
    }

    private void Update()
    {
        input = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if(targetTransform)
            transform.RotateAround(targetTransform.position, -Vector3.up, input * speed * Time.fixedDeltaTime);
    }
}
