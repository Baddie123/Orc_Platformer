using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour
{

	public Transform bulletStart;
	public GameObject bullet;

	
	void Update ()
	{
		if (Input.GetButtonDown("Fire1"))
		{

			Instantiate(bullet, bulletStart.position, bulletStart.rotation);
		}
	}
}
