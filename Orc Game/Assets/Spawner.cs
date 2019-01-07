using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

	public GameObject[] Enemy;	
	public Transform[] spawnPoints;



	public void OnTriggerEnter2D(Collider2D other)
	{
		bool isPlayer = other.CompareTag("Player");

		if (isPlayer)
		{
			for (int i = 0; i < spawnPoints.Length; i++)
			{
				Instantiate(Enemy[i], spawnPoints[i].position, spawnPoints[i].rotation);
			}
			Destroy(gameObject);
		}
		else
		{
			return;
		}
		
	}
}
