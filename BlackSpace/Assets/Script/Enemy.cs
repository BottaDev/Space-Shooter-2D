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
    }

    void TakeDamage()
    {
        hp -= 1;

        if (hp <= 0)
            Destroy(gameObject);
    }

    public enum EnemyType
    {
        Suicide,
        Shooter,
        Spawner,
    }

}
