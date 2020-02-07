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
            AddPoint();
            Destroy(gameObject);
        }
    }

    void CreateExplosion()
    {
        // Mostra explosion
    }

    void AddPoint()
    {
        if (enemyType == EnemyType.Suicide)
            GameManager.instance.AddCredits(1);
        else if (enemyType == EnemyType.Shooter)
            GameManager.instance.AddCredits(2);
        else if (enemyType == EnemyType.Spawner)
            GameManager.instance.AddCredits(3);
    }

    public enum EnemyType
    {
        Suicide,
        Shooter,
        Spawner,
    }

}
