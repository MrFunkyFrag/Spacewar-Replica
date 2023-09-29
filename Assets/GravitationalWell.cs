using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalWell : MonoBehaviour
{

    public float maxGravitationalForce = 100f;
    public float distanceScale = 1.0f;
    public float destroyRadius = 0.5f;

    private Vector2 center = new Vector2(0,0);

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vector2 direction = transform.position - other.transform.position;
            float distance = direction.magnitude;

            // Apply gravitational force using a logarithmic function
            float forceMagnitude = Mathf.Log(1 + distance) * maxGravitationalForce * distanceScale;

            // Normalize the direction and apply the force to the player
            if (distance > 0.1f)  // Avoid division by zero
            {
                Vector2 force = direction.normalized * forceMagnitude;
                other.attachedRigidbody.AddForce(force, ForceMode2D.Force);
            }

            if (distance < destroyRadius)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
