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
    public GameObject[] playerPrefab;

    float timeLeft;
    bool portalClosed;
    int currentCredits = 0;

    // PLAYER PREFS
    int totalEnemyKills;
    int currentShip = 0;
    int currentShipColor = 0;

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

        totalEnemyKills = PlayerPrefs.GetInt("Credits");
        currentShip = PlayerPrefs.GetInt("PlayerShip");
        currentShipColor = PlayerPrefs.GetInt("ShipColor");

        SpawnPlayer();
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

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Destroy(player.gameObject);

        PlayerPrefs.SetInt("EnemyKills", totalEnemyKills + currentCredits);
        PlayerPrefs.Save();
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

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        Vector2 spawnPos = player.transform.position;
        spawnPos += Random.insideUnitCircle.normalized * portalDistance;

        Instantiate(portalPrefab, spawnPos, Quaternion.identity);
    }

    void SpawnPlayer()
    {
        if (currentShip == 0)
        {
            if (currentShipColor == 0)
                Instantiate(playerPrefab[0], new Vector3(0, 0, 0), Quaternion.identity);
            else if (currentShipColor == 1)
                Instantiate(playerPrefab[1], new Vector3(0, 0, 0), Quaternion.identity);
            else if (currentShipColor == 2)
                Instantiate(playerPrefab[2], new Vector3(0, 0, 0), Quaternion.identity);
            else if (currentShipColor == 3)
                Instantiate(playerPrefab[3], new Vector3(0, 0, 0), Quaternion.identity);
        }
        else if (currentShip == 1)
        {
            if (currentShipColor == 0)
                Instantiate(playerPrefab[4], new Vector3(0, 0, 0), Quaternion.identity);
            else if (currentShipColor == 1)
                Instantiate(playerPrefab[5], new Vector3(0, 0, 0), Quaternion.identity);
            else if (currentShipColor == 2)
                Instantiate(playerPrefab[6], new Vector3(0, 0, 0), Quaternion.identity);
            else if (currentShipColor == 3)
                Instantiate(playerPrefab[7], new Vector3(0, 0, 0), Quaternion.identity);
        }
        else if (currentShip == 2)
        {
            if (currentShipColor == 0)
                Instantiate(playerPrefab[8], new Vector3(0, 0, 0), Quaternion.identity);
            else if (currentShipColor == 7)
                Instantiate(playerPrefab[9], new Vector3(0, 0, 0), Quaternion.identity);
            else if (currentShipColor == 8)
                Instantiate(playerPrefab[10], new Vector3(0, 0, 0), Quaternion.identity);
            else if (currentShipColor == 3)
                Instantiate(playerPrefab[11], new Vector3(0, 0, 0), Quaternion.identity);
        }

        print("Spawneo");
    }

    public void AddCredits(int credits)
    {
        currentCredits += credits;

        uiManager.SetCredits(currentCredits);
    }
}
