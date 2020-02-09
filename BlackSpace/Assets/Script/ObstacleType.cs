using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObstacleType
{
	public GameObject obstaclePrefab;

	[Range(0f, 1f)]
	public float spawnChance;
}
