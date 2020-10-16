using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatMannager : MonoBehaviour
{

	public Animator animator;
	private PlayerStats playerStats;
	private PlayerController playerController;
	private QuestionMannager questionMannager;
	private DifficultyMannager difficulty;



	public bool combatOpen;
	private int random;
	private string question;
	private float ans;

	private void Start()
	{
		playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		questionMannager = GameObject.FindGameObjectWithTag("GameMannager").GetComponent<QuestionMannager>();
		difficulty = GameObject.FindGameObjectWithTag("GameMannager").GetComponent<DifficultyMannager>();

		combatOpen = false;
	}

	public void StartCombat()
	{
		animator.SetBool("IsOpen", true);

		combatOpen = true;
	}

	public void Attack()
	{
		GameObject.FindGameObjectWithTag("Event").GetComponent<Monster>().Attack(playerStats.attack);
	}

	public void HealthPotion()
	{
		if (playerStats.healthPots <= 0) return;
		playerStats.healthPots -= 1;
		playerStats.health += 20;
	}

	public void MannaPotion()
	{
		if (playerStats.mannaPots <= 0) return;
		playerStats.mannaPots -= 1;
		playerStats.manna += 15;
	}

	public void Question()
	{
		random = Random.Range(1, 3);
		if (random == 1) questionMannager.Addition(difficulty.questionLength, difficulty.questionMin, difficulty.questionMax,out question,out ans);

	}

	public void EndCombat()
	{
		animator.SetBool("IsOpen", false);

		combatOpen = false;
	}

}
