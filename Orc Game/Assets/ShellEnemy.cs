using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellEnemy : MonoBehaviour
{


	public float speed;

	public float damage;

	private bool canHit = true;

	public float timeBetweenHits = 1f;

	private float starttimeBetweenHits;
	// Use this for initialization
	void Start ()
	{
		starttimeBetweenHits = timeBetweenHits;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeBetweenHits <= 0)
		{
			canHit = true;
		}
		else
		{
			timeBetweenHits -= Time.deltaTime;
		}
		
		//movement
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		bool isPlayer = other.CompareTag("Player");

		if (isPlayer && canHit)
		{
			Health player = other.GetComponent<Health>();
			player.TakeDamage(damage);
			canHit = false;
			timeBetweenHits = starttimeBetweenHits;
		}
		else
		{
			return;
		}
	}
}
