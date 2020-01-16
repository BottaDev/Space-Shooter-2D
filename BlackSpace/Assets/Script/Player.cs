using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool speedBuffActive = false;
    public bool rateBuffActive = false;

    float speedBuffDuration;    
    float rateBuffDuration;
    float defaultSpeed;
    float defaultRate;
    
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
        if (speedBuffActive)
        {
            if (speedBuffDuration > 0)
                speedBuffDuration -= Time.deltaTime;
            else if (speedBuffDuration <= 0)
            {
                speedBuffActive = false;
                speedBuffDuration = 0;
                playerController.SetSpeed(defaultSpeed);
            }
        }

        if (rateBuffActive)
        {
            if (rateBuffDuration > 0)
                rateBuffDuration -= Time.deltaTime;
            else if (rateBuffDuration <= 0)
            {
                rateBuffActive = false;
                rateBuffDuration = 0;
                playerShoot.SetFireRate(defaultRate);
            }
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

    void SetPowerUp(string type, float power, float duration, GameObject buffObject)
    {
        // Se destruyen los buff en esta funcion, porque el tiempo de respuesta de OnTriggerEnter2D es menor al OnTriggerEnter2D del player, lo que causa que 
        // nunca se destruya el buff si se utiliza su OnTriggerEnter2D

        switch (type)
        {
            case "Weapon":
                if (rateBuffDuration <= 0)
                {
                    playerShoot.SetFireRate(power);
                    rateBuffDuration = duration;
                    rateBuffActive = true;
                    Destroy(buffObject);
                }
                break;

            case "Speed":
                if (speedBuffDuration <= 0)
                {
                    playerController.SetSpeed(power);
                    speedBuffDuration = duration;
                    speedBuffActive = true;
                    Destroy(buffObject);
                }
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 10 || collision.gameObject.layer == 12)
            KillPlayer();

        if (collision.gameObject.layer == 13)
        {
            PowerUpController puc = collision.gameObject.GetComponent<PowerUpController>();
            
            SetPowerUp(puc.powerType.ToString(), puc.buff, puc.duration, collision.gameObject);
        }
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 12)
            KillPlayer();
    }
}
