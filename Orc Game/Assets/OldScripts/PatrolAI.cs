using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{


	public Transform groundCheck;
	private bool moveRight = true;
	public float speed = 2f;
	public float rayRange = 1f;
	public float damage = 10f;
	public float TimeBetweenHits = 1f;
	private float StartTimeBetweenHits;
	private bool hasHit = false;
	public int points;

	private void Start()
	{
		StartTimeBetweenHits = TimeBetweenHits;
	}

	void Update()
	{
		
		transform.Translate(Vector2.right * speed * Time.deltaTime);

		RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, rayRange);

		if (groundInfo == false)
		{
			if (moveRight)
			{
				transform.eulerAngles = new Vector3(0f, -180f, 0f);
				moveRight = false;
			}
			else
			{
				transform.eulerAngles = new Vector3(0f, 0f, 0f);
				moveRight = true;
			}
		}

		if (TimeBetweenHits <= 0)
		{
			hasHit = false;
			TimeBetweenHits = StartTimeBetweenHits;
		}
		else
		{
			TimeBetweenHits -= Time.deltaTime;
		}
		

	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		bool isPlayer = other.CompareTag("Player");
		if (isPlayer && !hasHit)
		{
			Health player = other.GetComponent<Health>();
			player.TakeDamage(damage);
			hasHit = true;
		}
		else
		{
			return;
		}
	}
}
