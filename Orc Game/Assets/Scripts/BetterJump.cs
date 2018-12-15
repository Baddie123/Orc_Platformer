using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{

	public float FallMulti = 2f;
	public float LowJumpMulti = 2.5f;
	
	private Rigidbody2D rb;
	// Use this for initialization
	void Awake ()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		if (rb.velocity.y < 0)
		{
			rb.velocity += Vector2.up * (FallMulti - 1) * Physics2D.gravity.y * Time.deltaTime;
		}else if (rb.velocity.y > 0 && Input.GetKey(KeyCode.W) == false)
		{
			rb.velocity += Vector2.up * (LowJumpMulti - 1) * Physics2D.gravity.y * Time.deltaTime;
		}

	}
}
