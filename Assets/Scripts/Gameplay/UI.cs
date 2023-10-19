using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI p1Lives;
    public TextMeshProUGUI p2Lives;
    public TextMeshProUGUI pWinTxt;
    public GameObject pauseMenu;
    public GameObject gameEndMenu;
    public static bool isGamePaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused) Resume();
            else Pause();
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        isGamePaused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);                
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LivesUpdate(int playerID, int lives)
    {    
        
        switch (playerID)
        {
            case 1:
                p1Lives.text = "P1 Lives: " + lives;
                break;
            case 2:
                p2Lives.text = "P2 Lives: " + lives;
                break;
            default:
                break;

        }

    }

    public void GameEnd(int playerID)
    {        
        gameEndMenu.SetActive(true);
        if (playerID == 0)
        {
            pWinTxt.text = "DRAW!";
        }
        else pWinTxt.text = "PLAYER " + playerID + " WINS!";

    }

}
