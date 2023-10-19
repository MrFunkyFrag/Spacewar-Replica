using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{  

    public float speed;
    public float lifeSpan;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Destroy(gameObject, lifeSpan);
    }

    void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
                
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent(out PlayerLives playerLives))
            {
                playerLives.PlayerTakeDamage();
            }
            else Debug.Log("No PlayerLives component!");
            
            Destroy(gameObject);
        }
    }
}
