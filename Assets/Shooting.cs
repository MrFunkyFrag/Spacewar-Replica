using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private Transform laserSpawnPoint;
        
    // fire rate variables
    private float canFire = 0f;
    public KeyCode fireKey;
    public float fireRate;

    void Update()
    {
        fireLaser(fireKey);        
    }

    private void fireLaser(KeyCode fireKey)
    {
        if (Input.GetKeyDown(fireKey))
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
