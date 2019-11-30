using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    //Camera
    [Tooltip("How high camera is offsetted from player")]
    [SerializeField] private float heightOffset = 0.5f;
    private CharacterController controller;
    private Camera cam;

    [Header("Mouse settings")]
    [SerializeField] private float sensitivityX = 15F;
    [SerializeField] private float sensitivityY = 15F;

    [SerializeField] private float minimumX = -360F;
    [SerializeField] private float maximumX = 360F;
    [SerializeField] private float minimumY = -60F;
    [SerializeField] private float maximumY = 60F;

    private float rotationX = 0F;
    private float rotationY = 0F;




    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main;
        cam.transform.SetParent(transform);
        cam.transform.SetPositionAndRotation(transform.position + Vector3.up * heightOffset, transform.rotation);
    }

    void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        throw new NotImplementedException();
    }

    private void Rotate()
    {
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationX += Input.GetAxis("Mouse X") * sensitivityX;

        rotationY = ClampAngle(rotationY, minimumY, maximumY);
        rotationX = ClampAngle(rotationX, minimumX, maximumX);

        Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.left);
        Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);

        cam.transform.rotation = xQuaternion * yQuaternion;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        angle = angle % 360;
        if ((angle >= -360F) && (angle <= 360F))
        {
            if (angle < -360F)
            {
                angle += 360F;
            }
            if (angle > 360F)
            {
                angle -= 360F;
            }
        }
        return Mathf.Clamp(angle, min, max);
    }
}
