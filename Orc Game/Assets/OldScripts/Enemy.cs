using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

	public float health = 100;
	private float maxhealth;
	private Transform target;
	public float speed;
	private float defaultSpeed;
	public float stopdistance;
	public float dazedtime = 0.6f;
	private float startDazedtime;
	private float timeBetweenShots;
	public float starttimeBetweenShots;
	public Image healthbar;
	private float ratio;
	public float height = 10f;

	public GameObject projectile;
	

	// Use this for initialization
	void Start ()
	{
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		defaultSpeed = speed;
		timeBetweenShots = starttimeBetweenShots;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		if (startDazedtime <= 0)
		{
			speed = defaultSpeed;
		}
		else
		{
			speed = 0;
			startDazedtime -= Time.deltaTime;
		}
		transform.position = Vector2.MoveTowards(transform.position, new Vector3(target.position.x, target.position.y + height, target.position.z), speed * Time.deltaTime);

		if (timeBetweenShots <= 0)
		{
			Instantiate(projectile, transform.position, Quaternion.identity);
			timeBetweenShots = starttimeBetweenShots;
		}
		else
		{
			timeBetweenShots -= Time.deltaTime;
		}
		
	}

}
