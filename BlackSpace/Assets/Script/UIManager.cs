using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("In Game")]
    public TextMeshProUGUI timer;
    public TextMeshProUGUI creditsText;
    public GameObject survive_Text;
    public GameObject escape_Text;

    [Header("Areas")]
    public GameObject tutorialArea;
    public GameObject menuArea;

    [Header("Texts")]
    public GameObject youWin_Text;
    public GameObject youLose_Text;
    public TextMeshProUGUI timePlayed_Text;
    public TextMeshProUGUI kills_Text;
    public TextMeshProUGUI wavesSurvived_Text;

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

    public void ShowMenu(bool playerWin, float timePlayed, int kills, int waves)
    {
        menuArea.SetActive(true);

        if (playerWin)
        {
            youWin_Text.SetActive(true);
            youLose_Text.SetActive(false);
        }
        else 
        {
            youWin_Text.SetActive(false);
            youLose_Text.SetActive(true);
        }

        timePlayed_Text.text = timePlayed.ToString("F2");
        kills_Text.text = kills.ToString();
        wavesSurvived_Text.text = waves.ToString();
    }

    public void SetSurviveText()
    {
        survive_Text.SetActive(true);
        escape_Text.SetActive(false); 
}

    public void SetEscapeText()
    {
        survive_Text.SetActive(false);
        escape_Text.SetActive(true);
    }

    public IEnumerator DisableTutorial()
    {
        yield return new WaitForSeconds(3f);

        tutorialArea.SetActive(false);

        yield return null;
    }
}
