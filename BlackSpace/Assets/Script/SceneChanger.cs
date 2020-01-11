using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public int sceneNumber;

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
