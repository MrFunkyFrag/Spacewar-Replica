using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public int playerLives;

    public void PlayerTakeDamage()
    {
        playerLives--;

        if (playerLives == 0)
        {
            Destroy(gameObject);
        }
    }
}
