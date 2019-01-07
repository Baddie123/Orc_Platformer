using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GunShot : MonoBehaviour
{

	public Transform bulletStart;
	public GameObject bullet;
	public int damage;
	public float Speed = 1000;

	
	void Update ()
	{
		Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - bulletStart.position;

		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

	
		
	
		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		
		

		bulletStart.rotation = Quaternion.Slerp(bulletStart.rotation, rotation, Speed * Time.deltaTime);
		
		if (Input.GetButtonDown("Fire1"))
		{

			Instantiate(bullet, bulletStart.position, rotation);
		}
	}

}
