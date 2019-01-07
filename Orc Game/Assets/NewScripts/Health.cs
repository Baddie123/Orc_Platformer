using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

	public float HP = 100f;
	public Image healthBar;
	public float ratio;
	private float maxHealth;
	public int newPoints = 10;
	private PlayerScore score;

	private void Start()
	{
		maxHealth = HP;
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		score = player.GetComponent<PlayerScore>();
	}


	public void TakeDamage(float dmg)
	{
		HP -= dmg;

		ratio = HP / maxHealth;

		if (healthBar != null){

			healthBar.rectTransform.localScale = new Vector3(ratio, 1f, 1f);
		}

	if (HP <= 0)
	{
			score.addPoints(newPoints);
			Destroy(gameObject);
		}
	}
	
}
