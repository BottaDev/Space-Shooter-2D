using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void KillPlayer()
    {
        CreateExplosion();
        Destroy(gameObject);
    }

    void CreateExplosion()
    {
        // Mostrar explosion
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 10 || collision.gameObject.layer == 12)
            KillPlayer();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 12)
            KillPlayer();
    }
}
