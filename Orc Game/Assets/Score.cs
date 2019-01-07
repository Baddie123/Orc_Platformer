using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

	public PlayerScore player;
	public Text playerScore;
	

	void Update ()
	{
		playerScore.text = "SCORE: " + player.points.ToString();
	}
}
