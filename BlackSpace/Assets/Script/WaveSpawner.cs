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

		if (Random.Range(0.0f, 1.0f) > 0.5) //%50 percent chance
			Instantiate(enemyPrefab[0], spawnPos, Quaternion.identity);

		if (Random.Range(0.0f, 1.0f) > 0.2) //%80 percent chance (1 - 0.2 is 0.8)
			Instantiate(enemyPrefab[1], spawnPos, Quaternion.identity);

		if (Random.Range(0.0f, 1.0f) > 0.7) //%30 percent chance (1 - 0.7 is 0.3)
			Instantiate(enemyPrefab[2], spawnPos, Quaternion.identity);
	}
}
