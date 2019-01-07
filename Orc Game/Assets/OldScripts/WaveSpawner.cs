using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

	
	public enum spawnState { SPAWNING, WAITING, COUNTING};
	
	[System.Serializable]
	public class Wave
	{
		public string waveName;
		public Transform enemy;
		public int amountEnemy;
		public float spawnRate;
	}

	public Wave[] waves;
	private int nextWave = 0;
	public float timeBetweenWaves = 5f;
	private float waveCountdown;

	public Transform[] spawnpoints;

	private float searchCountdown = 1;
	
	private spawnState state = spawnState.COUNTING;
	
	void Start()
	{
		waveCountdown = timeBetweenWaves;
	}

	private void Update()
	{
		if (state == spawnState.WAITING)
		{
			if (!EnemyIsAlive())
			{
				WaveCompleted();
			}
			else
			{
				return;
			}
		}
		
		if (waveCountdown <= 0 && state != spawnState.SPAWNING)
		{
			StartCoroutine( SpawnWave (waves[nextWave]) );
		}
		else
		{
			waveCountdown -= Time.deltaTime;
		}
	}

	IEnumerator SpawnWave(Wave _wave)
	{
		state = spawnState.SPAWNING;
		
		//spawning
		for (int i = 0; i < _wave.amountEnemy; i++)
		{
			SpawnEnemy(_wave.enemy);
			yield return new WaitForSeconds( 1f/ _wave.spawnRate);
		}
		
		state = spawnState.WAITING;
		yield break;
	}

	void SpawnEnemy(Transform enemy)
	{
		Transform sp = spawnpoints[Random.Range(0, spawnpoints.Length)];
		Instantiate(enemy, sp.position, sp.rotation);
		Debug.Log(enemy.name);
	}

	bool EnemyIsAlive()
	{

		searchCountdown -= Time.deltaTime;

		if (searchCountdown <= 0)
		{
			searchCountdown = 1f;
			if (GameObject.FindGameObjectWithTag("Enemy") == null)
			{
				return false;
			}
		}

		return true;
	}

	void WaveCompleted()
	{
		state = spawnState.COUNTING;
		waveCountdown = timeBetweenWaves;

		if (nextWave + 1 > waves.Length - 1)
		{
			nextWave = 0;
			Debug.Log("All Waves Complete. Looping.");
			return;
		}

		nextWave++;

	}
	
	
}
