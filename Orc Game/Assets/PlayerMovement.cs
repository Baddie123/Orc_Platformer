using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody2D rb;
	public float speed;

	private float horizontal;
	private float vertical;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");


	}
	
	// Update is called once per frame
	void FixedUpdate () {

		horizontal = Input.GetAxisRaw("Horizontal");
		vertical = Input.GetAxisRaw("Vertical");
		
		// input exists
		if (horizontal != 0 || vertical != 0)
		{
			rb.MovePosition(new Vector2(rb.position.x + (horizontal * speed), rb.position.y + (vertical * speed)) );
		}

		
		
		
		
	}
}
