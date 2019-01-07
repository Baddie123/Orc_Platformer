using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBlock : MonoBehaviour
{

	public int damage = 50;
	public float knockBackForce = 20f;

	public float TimeBetweenHits = 0.5f;
	private float startTimeBetweenHits;
	private bool canHit;

	private void Start()
	{
		startTimeBetweenHits = TimeBetweenHits;
	}

	private void Update()
	{
		if (TimeBetweenHits <= 0)
		{
			canHit = true;
		}
		else
		{
			TimeBetweenHits -= Time.deltaTime;
		}
	}

	// Use this for initialization
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (canHit)
		{
			Health health = other.GetComponent<Health>();
			health.TakeDamage(damage);
			Rigidbody2D player = other.GetComponent<Rigidbody2D>();
			player.velocity = new Vector2(player.velocity.x, knockBackForce);
			TimeBetweenHits = startTimeBetweenHits;
			canHit = false;
		}
	}
}
