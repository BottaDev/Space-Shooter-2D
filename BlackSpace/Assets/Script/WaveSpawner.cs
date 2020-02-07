using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
	[Header("Enemies")]
	public GameObject[] enemyPrefab;
	public float enemySpawnRate = 5f;
	public float enemySpawnRadius = 5f;
	float currentEnemyTime;

	[Header("Obstacles")]
	public GameObject[] obstaclePrefab;
	public float obstacleSpawnRate = 10f;
	public float obstacleSpawnRadius = 8f;
	float currentObstacleTime;

	GameObject player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");

		currentEnemyTime = 0;
		currentObstacleTime = 0;
	}

	void Update()
	{
		if (player == null)
			return;

		if (currentEnemyTime <= 0)
		{
			SpawnEnemy();
			currentEnemyTime = enemySpawnRate;
		}
		else
			currentEnemyTime -= Time.deltaTime;

		if (currentObstacleTime <= 0)
		{
			SpawnObstacle();
			currentObstacleTime = obstacleSpawnRate;
		} 
		else
			currentEnemyTime -= Time.deltaTime; 
	}

	void SpawnObstacle()
	{
		// Spawn Asteroides
		if (Random.Range(0.1f, 1.0f) > 0.4f)
		{
			if (Random.Range(0.1f, 1.0f) >= 0.6f)
			{
				Vector2 spawnPos = player.transform.position;
				spawnPos += Random.insideUnitCircle.normalized * enemySpawnRadius;

				Instantiate(obstaclePrefab[0], spawnPos, Quaternion.identity);
			}
			else
			{
				Vector2 spawnPos = player.transform.position;
				spawnPos += Random.insideUnitCircle.normalized * enemySpawnRadius;

				Instantiate(obstaclePrefab[1], spawnPos, Quaternion.identity);
			}
		}

		if (Random.Range(0.1f, 1.0f) > 0.8)
		{
			Vector2 spawnPos = player.transform.position;
			spawnPos += Random.insideUnitCircle.normalized * enemySpawnRadius;

			Instantiate(enemyPrefab[2], spawnPos, Quaternion.identity);
		}
	}

	void SpawnEnemy()
	{
		// Suicide %50 percent chance
		if (Random.Range(0.1f, 1.0f) > 0.5)
		{
			Vector2 spawnPos = player.transform.position;
			spawnPos += Random.insideUnitCircle.normalized * enemySpawnRadius;

			Instantiate(enemyPrefab[0], spawnPos, Quaternion.identity);
		} 

		// Shooter %80 percent chance (1 - 0.2 = 0.8)
		if (Random.Range(0.1f, 1.0f) > 0.2)
		{
			Vector2 spawnPos = player.transform.position;
			spawnPos += Random.insideUnitCircle.normalized * enemySpawnRadius;

			Instantiate(enemyPrefab[1], spawnPos, Quaternion.identity);
		} 

		// Spawner %30 percent chance (1 - 0.7 = 0.3)
		if (Random.Range(0.1f, 1.0f) > 0.7)
		{
			Vector2 spawnPos = player.transform.position;
			spawnPos += Random.insideUnitCircle.normalized * enemySpawnRadius;

			Instantiate(enemyPrefab[2], spawnPos, Quaternion.identity);
		} 
	}
}
