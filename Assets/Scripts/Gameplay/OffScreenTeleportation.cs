using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScreenTeleportation : MonoBehaviour
{
   
    private Camera mainCamera;
    private float cameraWidth;
    private float cameraHeight;

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
