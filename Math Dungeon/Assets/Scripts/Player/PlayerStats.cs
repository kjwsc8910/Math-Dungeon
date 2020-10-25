using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public float maxHealth;
	public float health;
	public int healthPots;

	public float maxManna;
	public float manna;
	public int mannaPots;

	public int attack;
	public float critRate;
	public float critDamage;

	public int level;
	public float exp;

	public float gold;

	private void Start()
	{

	}

	private void Update()
	{
		if (health > maxHealth) health = maxHealth;
		if (manna > maxManna) manna = maxManna;
		if (health <= 0) Debug.Log("Dead!");
	}
}
