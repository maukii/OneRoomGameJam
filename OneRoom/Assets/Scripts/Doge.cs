using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doge : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 5.0f;
    private Rigidbody rb;
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rb.MovePosition(transform.position + transform.forward * movementSpeed * Time.deltaTime);
            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("moving", false);
        }
    }

}
