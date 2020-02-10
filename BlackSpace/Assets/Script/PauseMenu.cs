﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUi;
    public Texture2D crossHairCursorTexture;
    public Texture2D pointerCursorTexture;

    void Awake()
    {
        Vector2 cursorHotspot = new Vector2(crossHairCursorTexture.width / 2, crossHairCursorTexture.height / 2);
        Cursor.SetCursor(crossHairCursorTexture, cursorHotspot, CursorMode.Auto);
    }

    void Start()
    {
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }    
    }

    public void Resume()
    {
        pauseMenuUi.SetActive(false);

        Vector2 cursorHotspot = new Vector2(crossHairCursorTexture.width / 2, crossHairCursorTexture.height / 2);
        Cursor.SetCursor(crossHairCursorTexture, cursorHotspot, CursorMode.Auto);

        Time.timeScale = 1;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUi.SetActive(true);

        Cursor.SetCursor(pointerCursorTexture, Vector2.zero, CursorMode.Auto);

        Time.timeScale = 0;
        GameIsPaused = true;
    }
}
