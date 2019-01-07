using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

	public Rigidbody2D rb;
	public float bulletSpeed = 20f;
	public int damage = 20;

	// Use this for initialization
	void Start () {
		rb.velocity = transform.right * bulletSpeed;
	}

	void OnTriggerEnter2D(Collider2D hitInfo)
	{

		
		bool isenemy = hitInfo.CompareTag("Enemy");
		bool isplayer = hitInfo.CompareTag("Player");
		

		
		if (isenemy)
		{
			Health enemy = hitInfo.GetComponent<Health>();
			enemy.TakeDamage(damage);
			Destroy(gameObject);
		}else if (isplayer)
		{
			return;
		}
		else
		{
			Destroy(gameObject);
		}
		
	}
}
