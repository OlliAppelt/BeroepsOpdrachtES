using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Vector3 jump;
    public float jumpForce = 2.0f;

    private bool canDoubleJump;
    public bool isGrounded;
    Rigidbody rb;

    public AudioSource JumpPlayer;
    public AudioSource LandPlayer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground")) { return; }

        LandPlayer.Play();
        isGrounded = true;
        canDoubleJump = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || canDoubleJump))
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);

            // If its grounded don't use the double jump.
            if (isGrounded)
            {
                isGrounded = false;
            }
            // Else we are using the double jump.
            else
            {
                canDoubleJump = false;
            }
        }
    }
}