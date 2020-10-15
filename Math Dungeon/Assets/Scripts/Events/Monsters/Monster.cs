using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

	public MonsterStats stats;
	public DialogueTrigger dialogue;
	public DialogueTrigger dialogue2;
	private DialogueMannager dialogueMannager;
	private PlayerController playerController;
	private CombatMannager combatMannager;
	private PlayerStats playerStats;
	private DifficultyMannager difficulty;

	private bool started = false;

	private void Start()
	{
		dialogueMannager = GameObject.FindGameObjectWithTag("GameMannager").GetComponent<DialogueMannager>();
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		combatMannager = GameObject.FindGameObjectWithTag("GameMannager").GetComponent<CombatMannager>();
		difficulty = GameObject.FindGameObjectWithTag("GameMannager").GetComponent<DifficultyMannager>();
		playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

		Invoke("StartEvent", 0.1f);
	}

	private void StartEvent()
	{
		dialogue.TriggerDialogue();
		started = true;
	}

	private void Update()
	{
		if (started == true && dialogueMannager.dialogueOpen == false)
		{
			Invoke("StartCombat", 1f);
			started = false;
		}
		if (stats.health <= 0) MonsterKilled();
	}

	private void StartCombat()
	{
		combatMannager.StartCombat();
	}

	public void Attack(int _attack)
	{
		stats.health -= _attack;
	}

	public void MonsterKilled()
	{
		playerStats.score += 10f * difficulty.multiplyer;
		combatMannager.EndCombat();
		dialogue2.TriggerDialogue();
		Destroy(gameObject);
	}
}
