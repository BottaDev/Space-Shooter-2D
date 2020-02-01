using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Level Settings")]
    public float levelTime = 120f;
    public float portalTime = 60f;
    public float portalDistance = 200f;

    [Header("Prefabs")]
    public GameObject portalPrefab;

    float timeLeft;
    bool portalClosed;

    UIManager uiManager;
    PowerUpDroppable pud;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        uiManager = GetComponent<UIManager>();
        pud = GetComponent<PowerUpDroppable>();

        uiManager.SetTimer(levelTime);

        timeLeft = levelTime;

        portalClosed = true;
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;

            uiManager.SetTimer(timeLeft);
        }    
        else if (timeLeft <= 0)
        {
            timeLeft = 0;

            if (portalClosed)
                SpawnPortal();
        }
    }

    public void DropPowerUp(Vector3 position)
    {
        pud.DropPowerUp(position);
    }

    public void WinGame()
    {
        uiManager.ShowMenu(true);
        print("YOU WIN!");
    }

    public void LoseGame()
    {
        uiManager.ShowMenu(false);
        print("YOU LOSE!");
    }

    public void SetPortalClosed()
    {
        portalClosed = true;

        timeLeft = levelTime;
    }

    void SpawnPortal()
    {
        portalClosed = false;

        GameObject player = GameObject.Find("Player");

        Vector2 spawnPos = player.transform.position;
        spawnPos += Random.insideUnitCircle.normalized * portalDistance;

        Instantiate(portalPrefab, spawnPos, Quaternion.identity);
    }
}
