using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI timer;

    public void SetTimer(float timeLeft)
    {
        timer.text = timeLeft.ToString("F2");
    }
}
