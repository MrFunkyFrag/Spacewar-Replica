using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public UI ui;

    private void Update()
    {
        
        if (player1 != null && player2 == null) // Player 1 win condition
        {
            ui.GameEnd(1);
            player1.SetActive(false);
        }
        else if (player1 == null && player2 != null) // Player 2 win condition
        {
            ui.GameEnd(2);
            player2.SetActive(false);
        }
        else if (player1 == null && player2 == null) // Draw condition
        {
            ui.GameEnd(0);
        }
    }
}
