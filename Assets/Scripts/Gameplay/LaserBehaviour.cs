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
            
            // To sa rzeczy z ktorymi mialem zawsze problemy i nie wiedzialem jak to powinno byc poprawnie zrobione.
            // Czy ponizszy sposob na komunikowanie obrazen jest dobry? Tzn. czy za kazdym razem przy kolizji musze
            // robic GetComponent tego skryptu? Czy jest na to jakis inny sposob?

            // Druga sprawa. Co jesli mam osobny skrypt "UI" w ktorym wizualnie przedstawiam liczbe zyc i tez
            // potrzebuje zakomunikowac update liczby zyc. Czy tak samo robie kolejny GetComponent tutaj do skryptu UI?
            
            // Idac dalej zalozmy ze mam kolejny skrypt do podmiany sprite'a na coraz bardziej uszkodzony statek. To znow
            // osobny GetCompnent?

            // Cos mi swita o eventach i nasluchiwaniu. Zdaje sie, ze to jest jakies lepsze rozwiazanie? Przyznam, ze to
            // jest cos czego nie wiem i nadawalo by sie na temat lekcji dla mnie, chyba ze to nie jest tu potrzebne.

            PlayerLives playerLives = other.GetComponent<PlayerLives>();
            if (playerLives != null)
            {
                playerLives.PlayerTakeDamage();
            }            
            Destroy(gameObject);
        }
    }
}
