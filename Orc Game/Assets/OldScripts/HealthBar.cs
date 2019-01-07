using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

	public Image currentHealthBar;
	public Text ratioText;

	private float health;
	private float maxhealth;

	private void Start()
	{
		maxhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().HP;
		
		health = maxhealth;
	}

	private void Update()
	{
		health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().HP;

		float ratiotemp = health / maxhealth;
		ratioText.text = health.ToString() + "HP";
		currentHealthBar.rectTransform.localScale = new Vector3(ratiotemp , 1f , 1f);
		
	}
}
