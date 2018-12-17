using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

	public Rigidbody2D rb;
	public float bulletSpeed = 20f;

	// Use this for initialization
	void Start () {
		rb.velocity = transform.right * bulletSpeed;
	}
	
	
}
