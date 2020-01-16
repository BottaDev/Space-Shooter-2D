using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float defaultSpeed;
    float defaultRate;
    [SerializeField]
    float speedBuffDuration;
    [SerializeField]
    float rateBuffDuration;

    PlayerShoot playerShoot;
    PlayerController playerController;

    void Awake()
    {
        playerShoot = GetComponent<PlayerShoot>();
        playerController = GetComponent<PlayerController>();

        defaultRate = playerShoot.fireRate;
        defaultSpeed = playerController.moveSpeed;
    }

    void Update()
    {
        CheckPowerUps();    
    }

    void CheckPowerUps()
    {
        if (speedBuffDuration > 0)
            speedBuffDuration -= Time.deltaTime;
        else if (speedBuffDuration <= 0)
        {
            speedBuffDuration = 0;
            playerController.SetSpeed(defaultSpeed);
        }
            
        if (rateBuffDuration > 0)
            rateBuffDuration -= Time.deltaTime;
        else if (rateBuffDuration <= 0)
        {
            rateBuffDuration = 0;
            playerShoot.SetFireRate(defaultRate);
        }
    }

    void KillPlayer()
    {
        CreateExplosion();
        Destroy(gameObject);
    }

    void CreateExplosion()
    {
        // Mostrar explosion
    }

    void SetPowerUp(string type, float power, float duration)
    {
        switch (type)
        {
            case "Weapon":
                if (rateBuffDuration <= 0)
                {
                    playerShoot.SetFireRate(power);
                    rateBuffDuration = duration;
                }
                break;

            case "Speed":
                if (speedBuffDuration <= 0)
                {
                    playerController.SetSpeed(power);
                    speedBuffDuration = duration;
                }
                break;
        }
    }

    public float GetRateBuffDuration()
    {
        return rateBuffDuration;
    }

    public float GetSpeedBuffDuration()
    {
        return speedBuffDuration;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 10 || collision.gameObject.layer == 12)
            KillPlayer();

        if (collision.gameObject.layer == 13)
        {
            PowerUpController puc = collision.gameObject.GetComponent<PowerUpController>();

            SetPowerUp(puc.powerType.ToString(), puc.buff, puc.duration);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 12)
            KillPlayer();
    }
}
