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
    public Pointer pointer;
    public GameObject portalPrefab;
    public GameObject[] playerPrefab;

    int currentCredits = 0;
    float surviveTimeLeft;
    float portalTimeLeft;
    bool portalClosed = true;
    bool surviveMode = true;
    bool gameFinished = false;

    // STATISTICS
    float totalSurvivedTime = 0;
    int kills = 0;
    int totalWavesPlayed = 0;

    // PLAYER PREFS
    int totalEnemyKills;
    int currentShip = 0;
    int currentShipColor = 0;

    UIManager uiManager;
    PowerUpDroppable pud;
    DifficultyProgression dp;
    GameObject player;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        uiManager = GetComponent<UIManager>();
        pud = GetComponent<PowerUpDroppable>();
        dp = GetComponent<DifficultyProgression>();

        uiManager.SetTimer(levelTime);

        surviveTimeLeft = levelTime;
        portalTimeLeft = portalTime;

        totalEnemyKills = PlayerPrefs.GetInt("Credits");
        currentShip = PlayerPrefs.GetInt("PlayerShip");
        currentShipColor = PlayerPrefs.GetInt("ShipColor");

        player = SpawnPlayer();
    }

    void Update()
    {
        if (gameFinished)
            return;

        if (surviveMode)
        {
            if (surviveTimeLeft > 0)
            {
                surviveTimeLeft -= Time.deltaTime;

                uiManager.SetTimer(surviveTimeLeft);
            }
            else if (surviveTimeLeft <= 0)
            {
                surviveTimeLeft = 0;

                uiManager.SetTimer(surviveTimeLeft);

                if (portalClosed)
                    SpawnPortal();
            }
        }
        else
        {
            if (portalTimeLeft > 0)
            {
                portalTimeLeft -= Time.deltaTime;

                uiManager.SetTimer(portalTimeLeft);
            }
            else if (portalTimeLeft <= 0)
            {
                portalTimeLeft = 0;

                uiManager.SetTimer(portalTimeLeft);
            }
        }

        totalSurvivedTime += Time.deltaTime;
    }

    public void DropPowerUp(Vector3 position)
    {
        pud.DropPowerUp(position);
    }

    public void WinGame()
    {
        uiManager.ShowMenu(true, totalSurvivedTime, kills, totalWavesPlayed);
        print("YOU WIN!");

        gameFinished = true;

        Destroy(player.gameObject);

        PlayerPrefs.SetInt("Credits", totalEnemyKills + currentCredits);
        PlayerPrefs.Save();
    }

    public void LoseGame()
    {
        uiManager.ShowMenu(false, totalSurvivedTime, kills, totalWavesPlayed);
        print("YOU LOSE!");

        gameFinished = true;
    }

    public void SetPortalClosed()
    {
        portalClosed = true;
        surviveMode = true;

        surviveTimeLeft = levelTime;

        uiManager.SetSurviveText();

        dp.IncreaseDifficulty();

        pointer.Hide();

        totalWavesPlayed++;
    }

    void SpawnPortal()
    {
        portalClosed = false;
        surviveMode = false;

        Vector2 spawnPos = player.transform.position;
        spawnPos += Random.insideUnitCircle.normalized * portalDistance;

        Instantiate(portalPrefab, spawnPos, Quaternion.identity);

        portalTimeLeft = portalTime;

        uiManager.SetEscapeText();

        pointer.Show(spawnPos);
    }

    GameObject SpawnPlayer()
    {
        if (currentShip == 0)
        {
            if (currentShipColor == 0)
                return Instantiate(playerPrefab[0], new Vector3(0, 0, 0), Quaternion.identity);
            else if (currentShipColor == 1)
                return Instantiate(playerPrefab[1], new Vector3(0, 0, 0), Quaternion.identity);
            else if (currentShipColor == 2)
                return Instantiate(playerPrefab[2], new Vector3(0, 0, 0), Quaternion.identity);
            else if (currentShipColor == 3)
                return Instantiate(playerPrefab[3], new Vector3(0, 0, 0), Quaternion.identity);
        }
        else if (currentShip == 1)
        {
            if (currentShipColor == 0)
                return Instantiate(playerPrefab[4], new Vector3(0, 0, 0), Quaternion.identity);
            else if (currentShipColor == 1)
                return Instantiate(playerPrefab[5], new Vector3(0, 0, 0), Quaternion.identity);
            else if (currentShipColor == 2)
                return Instantiate(playerPrefab[6], new Vector3(0, 0, 0), Quaternion.identity);
            else if (currentShipColor == 3)
                return Instantiate(playerPrefab[7], new Vector3(0, 0, 0), Quaternion.identity);
        }
        else if (currentShip == 2)
        {
            if (currentShipColor == 0)
                return Instantiate(playerPrefab[8], new Vector3(0, 0, 0), Quaternion.identity);
            else if (currentShipColor == 7)
                return Instantiate(playerPrefab[9], new Vector3(0, 0, 0), Quaternion.identity);
            else if (currentShipColor == 8)
                return Instantiate(playerPrefab[10], new Vector3(0, 0, 0), Quaternion.identity);
            else if (currentShipColor == 3)
                return Instantiate(playerPrefab[11], new Vector3(0, 0, 0), Quaternion.identity);
        }

        return null;
    }

    public void AddCredits(int credits)
    {
        currentCredits += credits;

        kills++;

        uiManager.SetCredits(currentCredits);
    }
}
