using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class FloatingHeadMovement : MonoBehaviour
{

	public float speedX = 10;
	public float speedY = 10;
	public Rigidbody2D rb;

	private bool hitRoof;
	private bool hitWall;
	
	public int damage = 10;
	public float TimeBetweenHits = 1f;
	private float StartTimeBetweenHits;
	private bool hasHit = false;


	public float checkSpeed = 1f;
	

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		StartTimeBetweenHits = TimeBetweenHits;
	}
	
	// Update is called once per frame
	void Update () {

		if (TimeBetweenHits <= 0)
		{
			hasHit = false;
			TimeBetweenHits = StartTimeBetweenHits;
		}
		else
		{
			TimeBetweenHits -= Time.deltaTime;
		}

		if (rb.velocity.y == 0)
		{
			speedY *= -1;
		}

		if (rb.velocity.x == 0)
		{
			speedX *= -1;
			transform.Rotate(0f, 180f, 0f);
		}
		rb.velocity = new Vector2(speedX, speedY);
		

		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		bool isplayer = other.CompareTag("Player");

		if (isplayer && !hasHit)
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
