using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomizationController : MonoBehaviour
{
    [Header("Variables")]
    public int[] creditsNeeded;
    public Sprite[] ships;
    public string[] shipName;

    [Header("UI")]
    public Image spriteShip;
    public TextMeshProUGUI colorText;
    public TextMeshProUGUI shipNameText;
    public TextMeshProUGUI CreditsText;
    public TextMeshProUGUI adviseText;
    public TextMeshProUGUI equipedText;

    // 1 = Hurricane
    // 2 = Confidence
    // 3 = Sparrow
    [Range(min: 0, max: 2)]
    public int currentShip = 0;

    // 1 = Blue
    // 2 = Green
    // 3 = Orange
    // 4 = Red
    [Range(min: 0, max: 3)]
    public int currentShipColor = 0;

    int totalCredits = 0;

    void Awake()
    {
        totalCredits =  PlayerPrefs.GetInt("Credits");
        currentShip = PlayerPrefs.GetInt("PlayerShip");
        currentShipColor = PlayerPrefs.GetInt("ShipColor");

        CreditsText.text = totalCredits.ToString();
        adviseText.enabled = false;

        ChangeColor(0);
        ChangeShip(0);
    }
    
    public void EquipShip()
    {
        // OPTIMIZAR

        if (currentShip == 0)
        {
            PlayerPrefs.SetInt("PlayerShip", currentShip);
            PlayerPrefs.SetInt("ShipColor", currentShipColor);
            PlayerPrefs.Save();

            equipedText.enabled = true;
            StartCoroutine(DisableText());
        }
        else if (currentShip == 1)
        {
            if (CheckKills(currentShip))
            {
                PlayerPrefs.SetInt("PlayerShip", currentShip);
                PlayerPrefs.SetInt("ShipColor", currentShipColor);
                PlayerPrefs.Save();

                equipedText.enabled = true;
                StartCoroutine(DisableText());
            }
            else
            {
                adviseText.enabled = true;
                adviseText.text = "You need " + creditsNeeded[0] + " credits to equip this ship!";
            }
        }
        else if (currentShip == 2)
        {
            if (CheckKills(currentShip))
            {
                PlayerPrefs.SetInt("PlayerShip", currentShip);
                PlayerPrefs.SetInt("ShipColor", currentShipColor);
                PlayerPrefs.Save();

                equipedText.enabled = true;
                StartCoroutine(DisableText());
            }
            else
            {
                adviseText.enabled = true;
                adviseText.text = "You need " + creditsNeeded[1] + " credits to equip this ship!";
            }
                
        }
    }

    bool CheckKills(int ship)
    {
        if (ship == 1)
        {
            if (totalCredits >= creditsNeeded[0])
                return true;
            else
                return false;
        }
        else if (ship == 2 && totalCredits >= creditsNeeded[1])
        {
            if (totalCredits >= creditsNeeded[1])
                return true;
            else
                return false;
        }

        return false;
    }

    public void ChangeColor(int index)
    {
        int tempCurrentShipColor = currentShipColor;
        currentShipColor += index;

        if (currentShipColor < 0 || currentShipColor > 3)
            currentShipColor = tempCurrentShipColor;

        if (currentShipColor == 0)
            colorText.color = Color.cyan;
        else if (currentShipColor == 1)
            colorText.color = Color.green;
        else if (currentShipColor == 2)
            colorText.color = new Color32(222, 83, 44, 255);
        else if (currentShipColor == 3)
            colorText.color = Color.red;

        ChangeSprite();
    }

    public void ChangeShip(int index)
    {
        int tempCurrentShip = currentShip;
        currentShip += index;

        if (currentShip < 0 || currentShip > 2)
            currentShip = tempCurrentShip;

        ChangeSprite();

        adviseText.enabled = false;
    }

    void ChangeSprite()
    {
        if (currentShip == 0)
        {
            if (currentShipColor == 0)
                spriteShip.sprite = ships[0];
            else if (currentShipColor == 1)
                spriteShip.sprite = ships[1];
            else if (currentShipColor == 2)
                spriteShip.sprite = ships[2];
            else if (currentShipColor == 3)
                spriteShip.sprite = ships[3];

            shipNameText.text = shipName[0];
        }
        else if (currentShip == 1)
        {
            if (currentShipColor == 0)
                spriteShip.sprite = ships[4];
            else if (currentShipColor == 1)
                spriteShip.sprite = ships[5];
            else if (currentShipColor == 2)
                spriteShip.sprite = ships[6];
            else if (currentShipColor == 3)
                spriteShip.sprite = ships[7];

            shipNameText.text = shipName[1];
        }
        else if (currentShip == 2)
        {
            if (currentShipColor == 0)
                spriteShip.sprite = ships[8];
            else if (currentShipColor == 1)
                spriteShip.sprite = ships[9];
            else if (currentShipColor == 2)
                spriteShip.sprite = ships[10];
            else if (currentShipColor == 3)
                spriteShip.sprite = ships[11];

            shipNameText.text = shipName[2];
        }
    }

    IEnumerator DisableText()
    {
        yield return new WaitForSeconds(1.5f);

        equipedText.enabled = false;

        yield return null;
    }
}
