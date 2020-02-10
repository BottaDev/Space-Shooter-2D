using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
	public Wave currentWave;

	GameObject player;
	float nextEnemySpawnTime = 1f;
	float nextObstacleSpawnTime = 1f;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if (player == null)
			return;

		if (Time.time >= nextEnemySpawnTime)
		{
			SpawnWave();
			nextEnemySpawnTime = Time.time + 1f / currentWave.enemySpawnRate;
		}

		if (Time.time >= nextObstacleSpawnTime)
		{
			SpawnObstacle();
			nextObstacleSpawnTime = Time.time + 1f / currentWave.obstacleSpawnRate;
		}
	}

	void SpawnWave()
	{
		foreach (EnemyType eType in currentWave.enemies)
		{
			if (Random.value <= eType.spawnChance)
			{
				Vector2 spawnPos = player.transform.position;
				spawnPos += Random.insideUnitCircle.normalized * currentWave.enemySpawnRadius;

				Instantiate(eType.enemyPrefab, spawnPos, Quaternion.identity);
			}
		}
	}
	
	void SpawnObstacle()
	{
		foreach (ObstacleType oType in currentWave.obstacles)
		{
			if (Random.value <= oType.spawnChance)
			{
				Vector2 spawnPos = player.transform.position;
				spawnPos += Random.insideUnitCircle.normalized * currentWave.obstacleSpawnRadius;

				Instantiate(oType.obstaclePrefab, spawnPos, Quaternion.identity);
			}
		}
	}
}
