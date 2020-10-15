using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

	public float health;
	public int attack;
	public float speed;
	public float manna;
	public int healthPots;
	public int mannaPots;
	public float score;

	private void Start()
	{
		health = 100f;
		attack = 15;
		speed = 10;
		manna = 75f;
		healthPots = 0;
		mannaPots = 0;
		score = 0f;
	}

	private void Update()
	{
		if (health > 100) health = 100;
		if (manna > 75) manna = 75;
		if (health <= 0) Debug.Log("Dead!");
	}
}
