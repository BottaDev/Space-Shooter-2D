using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bulletPrefab;
    [Range(0.1f, 1f)]
    public float fireRate = 0.5f;

    float currentRate = 0;

    void Update()
    {
        if (currentRate < 0)
            currentRate = 0;

        if (Input.GetButton("Fire1") && currentRate <= 0)
            Shoot();
        else
            currentRate -= Time.deltaTime;
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);

        currentRate = fireRate;
    }

    public void SetFireRate(float rate)
    {
        fireRate = rate;
    }
}
