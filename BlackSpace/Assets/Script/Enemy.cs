using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyType enemyType;
    public int hp = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
            TakeDamage();

        if (collision.gameObject.layer == 12)
        {
            CreateExplosion();
            Destroy(gameObject);
        }

    }

    void TakeDamage()
    {
        hp -= 1;

        if (hp <= 0)
        {
            CreateExplosion();
            GameManager.instance.DropPowerUp(transform.position);
            Destroy(gameObject);
        }
    }

    void CreateExplosion()
    {
        // Mostra explosion
    }

    public enum EnemyType
    {
        Suicide,
        Shooter,
        Spawner,
    }

}
