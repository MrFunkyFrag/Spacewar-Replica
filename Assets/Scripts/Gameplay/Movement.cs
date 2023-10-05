using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontalInput;
    private bool thrustInput;

    public KeyCode thrustKey;
    public string inputAxis;
    public float rotationSpeed;
    public float thrust;
    public float maxVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        HorizontalInput(inputAxis);
        ThrustInput(thrustKey);        

        transform.Rotate(Vector3.back, horizontalInput * rotationSpeed);     

    }

    private void FixedUpdate()
    {
        if (thrustInput)
        {
            rb.AddForce(transform.up * thrust);
        }

        // velocity limit to prevent being faster than projectiles
        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }

    }

    private void HorizontalInput(string inputAxis)
    {
        horizontalInput = Input.GetAxisRaw(inputAxis);
    }

    private void ThrustInput(KeyCode inputKey)
    {
        thrustInput = Input.GetKey(inputKey);
    }
}
