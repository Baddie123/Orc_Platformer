using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{

	public int points = 0;

	// Use this for initialization
	public void addPoints(int _points)
	{
		points += _points;
	}
}
