using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontal;

    public float rotationSpeed;
    public float thrust;
    public float maxVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");      

        transform.Rotate(Vector3.back, horizontal * rotationSpeed); 
        // nie wiem dlaczego akurat Vector3.back a nie Vector3.forward ale zakladam,
        // ze ma to cos wspolnego z orientacja sprite'a (zapewne podstawa
        // trojkata jest "przodem").

        if (Input.GetKey(KeyCode.S)) 
        {
            rb.AddForce(transform.up * thrust);
        }
        
        // velocity limit to prevent being faster than projectiles
        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;            
        }

    }
}
