using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {
    
    public int speed;
	public Rigidbody2D rb;

	private Transform player;
	private Vector2 target;
	public int damage;
	
	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = Vector2.MoveTowards(transform.position,new Vector2(player.position.x, player.position.y), speed * Time.deltaTime);
		rb = GetComponent<Rigidbody2D>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		Health player = other.GetComponent<Health>();
		bool enemy = other.CompareTag("Enemy");
		if (enemy)
		{
			return;
		}
		if (player != null)
		{
			player.TakeDamage(damage);
		}
		Destroy(gameObject);
	}
}
