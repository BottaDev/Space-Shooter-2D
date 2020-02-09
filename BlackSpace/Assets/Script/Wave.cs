using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
	[Header("Enemies")]
	public EnemyType[] enemies;
	public float enemySpawnRate = 1f;
	public float enemySpawnRadius = 5f;

	[Header("Obstacles")]
	public ObstacleType[] obstacles;
	public float obstacleSpawnRate = 10f;
	public float obstacleSpawnRadius = 8f;
}
