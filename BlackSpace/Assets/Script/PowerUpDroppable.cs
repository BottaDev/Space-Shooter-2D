using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDroppable : MonoBehaviour
{
    public GameObject[] ratePowerUps;
    public GameObject[] speedPowerUps;

    public void DropPowerUp(Vector3 position)
    {
        if (Random.Range(0.1f, 1.0f) >= 0.6f)
        {
            if (Random.Range(0.1f, 1.0f) >= 0.9f)
                Instantiate(ratePowerUps[1], position, Quaternion.identity);
            else if (Random.Range(0.1f, 1.0f) > 0.8f)
                Instantiate(ratePowerUps[0], position, Quaternion.identity);
        }
        else
        {
            if (Random.Range(0.1f, 1.0f) >= 0.9f)
                Instantiate(speedPowerUps[1], position, Quaternion.identity);
            else if (Random.Range(0.1f, 1.0f) > 0.8f)
                Instantiate(speedPowerUps[0], position, Quaternion.identity);
        }
    }
}
