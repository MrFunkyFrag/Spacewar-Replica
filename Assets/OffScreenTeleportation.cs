using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScreenTeleportation : MonoBehaviour
{
    // uzylem tego samego skryptu dla gracza i dla lasera. Jest to ok, czy
    // raczej nie nalezy tak robic?

    private Camera mainCamera;
    private float cameraWidth;
    private float cameraHeight;

    // ponizsze rozwiazanie zawijania pozycji gracza ma taki minus ze pole gry
    // jest zalezne od proporcji ekranu
    // po przemysleniu chyba powinienem to inaczej rozwiazac
    // pole gry powinno byc takie samo niezalezne od proporcji ekranu

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        cameraWidth = mainCamera.orthographicSize * 2 * mainCamera.aspect;
        cameraHeight = mainCamera.orthographicSize * 2;
    }

    // Update is called once per frame
    void Update()
    {
        TeleportIfOffScreen();
    }

    private void TeleportIfOffScreen()
    {
        Vector3 currentPosition = transform.position;

        if (currentPosition.x > cameraWidth / 2)
        {
            currentPosition.x = -cameraWidth / 2;
        }
        else if (currentPosition.x < -cameraWidth / 2)
        {
            currentPosition.x = cameraWidth / 2;
        }

        if (currentPosition.y > cameraHeight / 2)
        {
            currentPosition.y = -cameraHeight / 2;
        }
        else if (currentPosition.y < -cameraHeight /2)
        {
            currentPosition.y = cameraHeight / 2;
        }

        transform.position = currentPosition;
    }
}
