using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Level Settings")]
    public float levelTime = 60f;
    float timeLeft;

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
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        uiManager.SetTimer(timeLeft);
    }

    public void DropPowerUp(Vector3 position)
    {
        pud.DropPowerUp(position);
    }
}
