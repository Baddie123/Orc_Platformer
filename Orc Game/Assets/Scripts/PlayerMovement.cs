using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody2D rb;
	public float speed;
	public float jumpforce;

	private bool FaceRight = true;
	private float horizontal;

	public LayerMask WhatIsGround;
	public Transform GroundCheck;
	public float CheckRadius;
	private bool isGrounded;

	private int JumpCount;
	public int Jumps;
	

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		horizontal = Input.GetAxis("Horizontal");
		Debug.Log("Hello");

	}

	void Update()
	{
		Debug.Log(isGrounded);
		if (isGrounded == true)
		{
			JumpCount = Jumps;
		}

		if (Input.GetKeyDown(KeyCode.W) && JumpCount > 0)
		{
			rb.velocity = Vector2.up * jumpforce;
			JumpCount--;
		}else if (Input.GetKeyDown(KeyCode.W) && JumpCount == 0 && isGrounded == true)
		{
			rb.velocity = Vector2.up * jumpforce;
		}
		
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{

		isGrounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, WhatIsGround);
		horizontal = Input.GetAxisRaw("Horizontal");
		
		if (horizontal < 0 && FaceRight == true)
		{
			Flip();
		}

		if (horizontal > 0 && FaceRight == false)
		{
			Flip();
		}
		// input exists
		rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);	
		
	}

	void Flip()
	{
		FaceRight = !FaceRight;
		Vector3 scalar = transform.localScale;
		scalar.x *= -1;
		transform.localScale = scalar;
	}
	
}
