using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public int playerID;
    public int playerLives;
    public UI ui;    

    private Vector3 minSpawnPos = new Vector3(-35, -19, 0);
    private Vector3 maxSpawnPos = new Vector3(35, 19, 0);
    private SpriteRenderer spRenderer;
    private BoxCollider2D bc2d;

    private void Awake()
    {
        spRenderer = GetComponent<SpriteRenderer>();
        bc2d = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        ui.LivesUpdate(playerID, playerLives);
    }

    public void PlayerTakeDamage()
    {
        playerLives--;
        ui.LivesUpdate(playerID, playerLives);

        if (playerLives == 0)
        {            
            Destroy(gameObject);
        }
        else
        {
            float randomX = Random.Range(minSpawnPos.x, maxSpawnPos.x);
            float randomY = Random.Range(minSpawnPos.y, maxSpawnPos.y);

            Vector3 randomSpawnPos = new Vector3(randomX, randomY, 0);

            transform.position = randomSpawnPos;

            StartCoroutine(Blink(3));
            StartCoroutine(SpawnImmunity(3));

        }
    }

    IEnumerator Blink(float duration)
    {        
        var endTime = Time.time + duration;
        while (Time.time < endTime)
        {            
            spRenderer.enabled = false;
            yield return new WaitForSeconds(0.15f);
            spRenderer.enabled = true;
            yield return new WaitForSeconds(0.15f);
        }
    }

    IEnumerator SpawnImmunity(float duration)
    {
        bc2d.enabled = false;
        yield return new WaitForSeconds(duration);
        bc2d.enabled = true;
    }
}
