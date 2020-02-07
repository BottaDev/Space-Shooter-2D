using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public TextMeshProUGUI creditsText;
    public GameObject tutorialArea;
    public GameObject youWin_Text;
    public GameObject youLose_Text;
    public GameObject menu;

    void Start()
    {
        StartCoroutine(DisableTutorial());    
    }

    public void SetTimer(float timeLeft)
    {
        timer.text = timeLeft.ToString("F2");
    }

    public void SetCredits(int credits)
    {
        creditsText.text = "" + credits.ToString("0000");
    }

    public void ShowMenu(bool playerWin)
    {
        menu.SetActive(true);

        if (playerWin)
            youWin_Text.SetActive(true);
        if (!playerWin)
            youLose_Text.SetActive(true);
    }

    public IEnumerator DisableTutorial()
    {
        yield return new WaitForSeconds(3f);

        tutorialArea.SetActive(false);

        yield return null;
    }
}
