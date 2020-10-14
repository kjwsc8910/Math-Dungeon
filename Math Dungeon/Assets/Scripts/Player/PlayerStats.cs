using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

	private float health;
	private int attack;

	private void Start()
	{
		health = 100f;
		attack = 15;
	}
}
