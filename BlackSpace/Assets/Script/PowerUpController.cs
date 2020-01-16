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

    bool isGrowing = false;

    void Start()
    {
        Destroy(gameObject, 60f);
    }

    void Update()
    {
        if (!isGrowing)
        {
            transform.localScale -= new Vector3(effectSpeed, effectSpeed, effectSpeed);
            if (transform.localScale.x <= 1)
                isGrowing = true;
        }
        else
        {
            transform.localScale += new Vector3(effectSpeed, effectSpeed, effectSpeed);
            if (transform.localScale.x >= 2)
                isGrowing = false;
        }
    }

    public enum PowerUpType
    {
        Weapon,
        Speed,
    }
}
