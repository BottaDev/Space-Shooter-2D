using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
	public GameObject[] enemyPrefab;
	public float spawnRate;
	public float spawnRadius = 5f;

	GameObject player;
	float currentTime;

	void Start()
	{
		player = GameObject.Find("Player");
		currentTime = 0;
	}

	void Update()
	{
		if (player == null)
			return;

		if (currentTime <= 0)
		{
			SpawnEnemy();
			currentTime = spawnRate;
		}
		else
			currentTime -= Time.deltaTime;
	}

	void SpawnEnemy()
	{
		Vector2 spawnPos = player.transform.position;
		spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

		// Suicide %50 percent chance
		if (Random.Range(0.0f, 1.0f) > 0.5) 
			Instantiate(enemyPrefab[0], spawnPos, Quaternion.identity);

		// Shooter %80 percent chance (1 - 0.2 = 0.8)
		if (Random.Range(0.0f, 1.0f) > 0.2) 
			Instantiate(enemyPrefab[1], spawnPos, Quaternion.identity);

		// Spawner %30 percent chance (1 - 0.7 = 0.3)
		if (Random.Range(0.0f, 1.0f) > 0.7) 
			Instantiate(enemyPrefab[2], spawnPos, Quaternion.identity);
	}
}
