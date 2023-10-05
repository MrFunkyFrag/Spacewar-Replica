using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class MainMenu : MonoBehaviour
{
    public GameObject firstButton;

    public void Update()
    {
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (verticalInput != 0 && EventSystem.current.currentSelectedGameObject == null )
        {
            EventSystem.current.SetSelectedGameObject(firstButton);
        }
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    
    

}
