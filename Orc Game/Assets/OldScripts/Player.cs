using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


	private Rigidbody2D rb;
	public float knockbackX;
	public float knockbackY;

	public int health = 100;
	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		
	}

	private void Update()
	{
		if (health <= 0)
		{
			Destroy(gameObject);
		}
	}


	public void TakeDamage(int damage)
	{
		health -= damage;
		rb.velocity = new Vector2(knockbackX,knockbackY);
	}
}
