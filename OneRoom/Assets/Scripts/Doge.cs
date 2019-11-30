using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doge : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 5.0f;
    private Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rb.MovePosition(transform.position + transform.forward * movementSpeed * Time.deltaTime);
        }
    }

}
