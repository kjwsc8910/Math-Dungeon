using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CombatMannager : MonoBehaviour
{

	public Animator animator;
	private PlayerStats playerStats;
	private PlayerController playerController;
	private QuestionMannager questionMannager;
	private DifficultyMannager difficulty;

	public GameObject playerTurnUI;
	public GameObject questionUI;
	public TextMeshProUGUI questionText;
	public InputField questionInput;

	private Monster monster;
	private float damage;

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

	public void StartCombat(Monster _monster)
	{
		monster = _monster;

		questionUI.gameObject.SetActive(false);
		playerTurnUI.gameObject.SetActive(true);

		animator.SetBool("IsOpen", true);

		combatOpen = true;
	}

	public void Attack()
	{
		random = Random.Range(1, 3);
		if (random == 1) questionMannager.Addition(difficulty.questionLength, difficulty.questionMin, difficulty.questionMax, out question, out ans);
		if (random == 2) questionMannager.Subtraction(difficulty.questionLength, difficulty.questionMin, difficulty.questionMax, out question, out ans);

		questionText.text = question;
		questionInput.text = "";

		playerTurnUI.gameObject.SetActive(false);
		questionUI.gameObject.SetActive(true);
	}

	public void AttackCheck()
	{
		if (questionInput.text == ans.ToString())
		{		
			damage = playerStats.attack;

			random = Random.Range(0, 101);
			if (random <= playerStats.critRate) damage *=  1 + playerStats.critDamage / 100;

			Debug.Log(damage);

			monster.stats.health -= damage;

			if (monster.stats.health > 0)
			{
				questionUI.gameObject.SetActive(false);
				playerTurnUI.gameObject.SetActive(true);
			}
			else
			{
				EndCombat();
			}
		}
		else
		{
			playerStats.health -= monster.stats.attack;
		}
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

	public void EndCombat()
	{
		animator.SetBool("IsOpen", false);

		combatOpen = false;
	}

}
