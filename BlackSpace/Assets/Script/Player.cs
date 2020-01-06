using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 10)
            KillPlayer();
    }

    void KillPlayer()
    {
        // Mostrar explosion
        Destroy(gameObject);
    }
}
