using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public GameObject youWin_Text;
    public GameObject youLose_Text;
    public GameObject menu;

    public void SetTimer(float timeLeft)
    {
        timer.text = timeLeft.ToString("F2");
    }

    public void ShowMenu(bool playerWin)
    {
        menu.SetActive(true);

        if (playerWin)
            youWin_Text.SetActive(true);
        if (!playerWin)
            youLose_Text.SetActive(true);
    }
}
