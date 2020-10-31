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

	public TextMeshProUGUI combatText;
	[TextArea(3, 10)]
	public string[] sentencesGood;
	[TextArea(3, 10)]
	public string[] sentencesBad;
	private string sentence;

	private Monster monster;
	private float damage;
	private bool crit;

	public bool combatOpen;
	private int random;
	private string question;
	[SerializeField]
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

			crit = false;
			random = Random.Range(0, 101);
			if (random <= playerStats.critRate) { damage *= 1 + playerStats.critDamage / 100; crit = true; }

			monster.stats.health -= damage;

			CombatTextGood();
		}
		else
		{

			damage = monster.stats.attack;

			crit = false;
			random = Random.Range(0, 101);
			if (random <= monster.stats.critRate) { damage *= 1 + monster.stats.critDamage / 100; crit = true; }

			playerStats.health -= damage;

			CombatTextBad();
		}
	}

	public void CombatTextGood()
	{
		sentence = sentencesGood[Random.Range(0, sentencesGood.Length)];
		sentence += damage;
		sentence += " Damage!";
		if (crit == true) sentence += " It was a critical strike!";
		monster.subjectAnimator.SetTrigger("TakeDamage");
		combatText.gameObject.SetActive(true);
		questionUI.SetActive(false);
		StopAllCoroutines();
		StartCoroutine(DisplayText(sentence));
	}

	public void CombatTextBad()
	{
		sentence = sentencesBad[Random.Range(0, sentencesBad.Length)];
		sentence += damage;
		sentence += " Damage!";
		if (crit == true) sentence += " It was a critical strike!";
		combatText.gameObject.SetActive(true);
		questionUI.SetActive(false);
		StopAllCoroutines();
		StartCoroutine(DisplayText(sentence));
	}

	public void ContinueCombat()
	{
		combatText.gameObject.SetActive(false);
		questionUI.SetActive(false);
		playerTurnUI.SetActive(true);

		if (monster.stats.health <= 0)
		{
			EndCombat();
		}
	}

	IEnumerator DisplayText (string sentence)
	{
		combatText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			combatText.text += letter;
			yield return null;
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

		monster.subjectAnimator.ResetTrigger("TakeDamage");

		combatOpen = false;
	}

}
