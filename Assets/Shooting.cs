using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private Transform laserSpawnPoint;

    // przypomnialem sobie dlaczego w moich skryptach zawsze mam
    // przemieszane variables prywatne z publicznymi, to dlatego, ze ja nie sortuje ich
    // wedlug access type tylko wedlug dzielonej funkcjonalnosci. Czy doradzasz segregowac
    // je w Twój sposob?

    // fire rate variables
    private float canFire = 0f;
    public float fireRate;

    // Start is called before the first frame update
    void Start()
    {
       
    }


    void Update()
    {
        fireLaser();        
    }

    private void fireLaser()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (Time.time > canFire)
            {
                canFire = Time.time + fireRate;

                Vector3 spawnPos = laserSpawnPoint.position;
                Quaternion spawnRot = laserSpawnPoint.rotation;
                Instantiate(laserPrefab, spawnPos, spawnRot);
            }

        }
    }
}
