using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
{
    public Sprite[] sprites;

    SpriteRenderer sp;

    void Awake()
    {
        sp = GetComponent<SpriteRenderer>();

        int sprite = Random.Range(0, sprites.Length);

        sp.sprite = sprites[sprite];
    }

    void Start()
    {
        Destroy(gameObject, 0.1f);
    }
}
