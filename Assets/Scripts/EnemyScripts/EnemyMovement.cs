using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    private float movement;

    private Rigidbody body;

    private void Start()
    {
        movement = speed;
        body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        body.velocity = new Vector3(movement, body.velocity.y);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Boundary")) { return; }

        movement *= -1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player")) { return; }

        movement *= -1;
    }
}
