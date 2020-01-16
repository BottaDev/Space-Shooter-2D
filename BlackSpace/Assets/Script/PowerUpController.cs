using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public PowerUpType powerType; 
    public float buff;
    public float duration = 10f;
    [Range(0.01f, 0.05f)]
    public float effectSpeed;

    bool isGroing = false;

    void Update()
    {
        if (!isGroing)
        {
            transform.localScale -= new Vector3(effectSpeed, effectSpeed, effectSpeed);
            if (transform.localScale.x <= 1)
                isGroing = true;
        }
        else
        {
            transform.localScale += new Vector3(effectSpeed, effectSpeed, effectSpeed);
            if (transform.localScale.x >= 2)
                isGroing = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if ((powerType == PowerUpType.Weapon && player.GetRateBuffDuration() <= 0) || (powerType == PowerUpType.Speed && player.GetSpeedBuffDuration() <= 0))
                Destroy(gameObject);
        }
    }

    public enum PowerUpType
    {
        Weapon,
        Speed,
    }
}
