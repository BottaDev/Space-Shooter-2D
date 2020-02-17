using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyProgression : MonoBehaviour
{
	public int difficulty = 1;

	public Wave[] wave;
	public WaveSpawner waveSpawner;

	void Start()
	{
		waveSpawner.currentWave = wave[0];
	}

	public void IncreaseDifficulty()
	{
		difficulty += 1;

		if (difficulty > 4)
		{
			int i = wave.Length - 1;

			wave[i].enemySpawnRate -= 0.1f;
			wave[i].enemySpawnRadius += 0.1f;

			waveSpawner.currentWave = wave[i];
		}
		else
			waveSpawner.currentWave = wave[difficulty - 1];
	}
}
