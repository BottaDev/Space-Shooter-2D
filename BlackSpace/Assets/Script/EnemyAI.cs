using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = .1f;
    public float repelForce = 1f;
    public float repelRange = .2f;

    [Header("Shooter")]
    public float shootDistance = 3.5f;
    public float rotationDistance = 2.8f;
    public float shootingSpeed = 1.5f;
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public float fireRate = 1f;
    float currentShootRate = 0;
    bool goToRight;

    [Header("Spawner")]
    public float stopDistance = 4f;
    public float spawnRate = 5f;
    public GameObject enemyPrefab;
    public Transform[] enemySpawnPoints = new Transform[4];
    float currentSpawnRate = 0;

    // GENERAL
    static List<Rigidbody2D> EnemyRBs;
    Enemy enemyStats;
    Rigidbody2D rb;
    GameObject player;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        enemyStats = gameObject.GetComponent<Enemy>();

        if (EnemyRBs == null)
        {
            EnemyRBs = new List<Rigidbody2D>();
        }

        EnemyRBs.Add(rb);

        
        if(enemyStats.enemyType == Enemy.EnemyType.Shooter)
        {
            // Direccion de giro al disparar
            goToRight = Random.Range(0, 2) == 0 ? true : false;

            fireRate = Random.Range(1.0f, 1.5f);
        }


        if (enemyStats.enemyType == Enemy.EnemyType.Spawner)
            currentSpawnRate = spawnRate;
    }

    void FixedUpdate()
    {
        if (player == null)
            return;

        Vector3 direction = player.transform.position - transform.position;
        Vector2 newPos;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        if (enemyStats.enemyType == Enemy.EnemyType.Suicide)
        {
            rb.rotation = Mathf.LerpAngle(rb.rotation, angle, turnSpeed);

            newPos = CalculatePosition(direction);

            rb.MovePosition(newPos);
        }
        else if (enemyStats.enemyType == Enemy.EnemyType.Shooter)
        {
            float distance = Vector2.Distance(rb.position, player.transform.position);

            rb.rotation = angle;

            if (distance > rotationDistance)
                newPos = CalculatePosition(direction);
            else
                newPos = CalculatePositionShooting(direction);
            
            if (currentShootRate < 0)
                currentShootRate = 0;

            if (currentShootRate <= 0 && distance <= shootDistance)
                Shoot();
            else
                currentShootRate -= Time.fixedDeltaTime;

            rb.MovePosition(newPos);
        }
        else if (enemyStats.enemyType == Enemy.EnemyType.Spawner)
        {
            float distance = Vector2.Distance(rb.position, player.transform.position);

            rb.rotation = angle;

            if (currentSpawnRate < 0)
                currentSpawnRate = 0;
            else if (currentSpawnRate > 0)
                currentSpawnRate -= Time.fixedDeltaTime;
                

            if (distance > stopDistance)
            {
                newPos = CalculatePosition(direction);

                rb.MovePosition(newPos);
            }
            else if (currentSpawnRate <= 0)
                SpawnEnemies();
        }
    }

    Vector2 CalculatePosition(Vector2 direction)
    {
        Vector2 repelForce = Vector2.zero;
        foreach (Rigidbody2D enemy in EnemyRBs)
        {
            if (enemy == rb)
                continue;

            if (Vector2.Distance(enemy.position, rb.position) <= repelRange)
            {
                Vector2 repelDir = (rb.position - enemy.position).normalized;
                repelForce += repelDir;
            }
        }

        Vector2 newPos = transform.position + transform.up * Time.fixedDeltaTime * moveSpeed;
        newPos += repelForce * Time.fixedDeltaTime * this.repelForce;

        return newPos;
    }

    Vector2 CalculatePositionShooting(Vector2 direction)
    {
        Vector2 repelForce = Vector2.zero;
        foreach (Rigidbody2D enemy in EnemyRBs)
        {
            if (enemy == rb)
                continue;

            if (Vector2.Distance(enemy.position, rb.position) <= repelRange)
            {
                Vector2 repelDir = (rb.position - enemy.position).normalized;
                repelForce += repelDir;
            }
        }

        Vector2 newPos;

        if (goToRight)
           newPos  = transform.position + transform.right * Time.fixedDeltaTime * shootingSpeed;
        else
            newPos = transform.position + transform.right * -1 * Time.fixedDeltaTime * shootingSpeed;

        newPos += repelForce * Time.fixedDeltaTime * this.repelForce;

        return newPos;
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);

        currentShootRate = fireRate;
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < enemySpawnPoints.Length; i++)
            Instantiate(enemyPrefab, enemySpawnPoints[i].position, enemySpawnPoints[i].rotation);

        currentSpawnRate = spawnRate;
    }

    void OnDestroy()
    {
        EnemyRBs.Remove(rb);
    }

    /*private void OnDrawGizmos()
    {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, shootDistance);
    }*/
}
