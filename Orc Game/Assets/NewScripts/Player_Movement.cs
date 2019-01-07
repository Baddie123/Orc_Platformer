using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

	private Rigidbody2D rb;
	private Animator anim;
	

	public float speed = 10f;
	public float jumpForce = 20f;
	private float horizontal;

	public float lowJumpMult = 2.5f;
	public float highJumpMult = 2.0f;

	public Transform groundCheck;
	private bool isGrounded;
	private float circRadius = 0.1f;
	public LayerMask WhatIsGround;
	public bool faceRight = true;

	public int Jumps;
	private int jumpCount;
	private float timeBetweenGroundChecks = 0.2f;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update ()
	{		
		// multiple Jumps
		if (isGrounded && timeBetweenGroundChecks <= 0)
		{
			jumpCount = Jumps;
			timeBetweenGroundChecks = 0.2f;
			anim.SetBool("IsJumping", false);
		}
		else
		{
			timeBetweenGroundChecks -= Time.deltaTime;
		}
		if (Input.GetKeyDown("w") && jumpCount > 0)
		{
			rb.velocity = Vector2.up * jumpForce;
			
			jumpCount--;
		}
		else if (Input.GetKeyDown("w") && jumpCount == 0 && isGrounded)
		{
			rb.velocity = Vector2.up * jumpForce;
			
		}

		if (!isGrounded)
		{
			anim.SetBool("IsJumping", true);
		}

		// Better Jumping
		if (rb.velocity.y < 0)
		{
			rb.velocity += Vector2.up * (highJumpMult - 1) * Physics2D.gravity.y * Time.deltaTime;
		}
		else if (rb.velocity.y > 0 && Input.GetKey(KeyCode.W) == false)
		{
			rb.velocity += Vector2.up * (lowJumpMult - 1) * Physics2D.gravity.y * Time.deltaTime;
		}
		
		
	}

	private void FixedUpdate()
	{
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, circRadius, WhatIsGround);
		
		horizontal = Input.GetAxisRaw("Horizontal");

		if (horizontal < 0 && faceRight)
		{
			Flip();
		}

		if (horizontal > 0 && !faceRight)
		{
			Flip();
		}

		if (Input.GetKey(KeyCode.L) && !faceRight)
		{
			Flip();
		}
		if (Input.GetKey(KeyCode.J) && faceRight)
		{
			Flip();
		}
		
		rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
		anim.SetFloat("Speed", Mathf.Abs(horizontal));
	}

	private void Flip()
	{
		faceRight = !faceRight;
		transform.Rotate(0f, 180f, 0f);
	}
}
