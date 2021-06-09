using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody myRigidbody;

    [SerializeField]
    private float Speed;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        HandleMovement(horizontal);
    }

    private void HandleMovement(float horizontal)
    {

        myRigidbody.velocity = new Vector3(horizontal * Speed, myRigidbody.velocity.y);
    }
}
