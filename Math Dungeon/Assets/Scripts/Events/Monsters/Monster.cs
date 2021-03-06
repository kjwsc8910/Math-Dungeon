﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{

	public MonsterStats stats;
	public DialogueTrigger dialogue;
	public DialogueTrigger dialogue2;
	private DialogueMannager dialogueMannager;
	private PlayerController playerController;
	private CombatMannager combatMannager;

	[HideInInspector]
	public PlayerStats playerStats;

	private DifficultyMannager difficulty;

	[HideInInspector]
	public Image subject;

	private SubjectMannager subjectScript;

	[HideInInspector]
	public Monster monster;

	[HideInInspector]
	public Animator subjectAnimator;

	private Animator dim;

	private bool started = false;
	private bool dead = false;

	private void Start()
	{
		dialogueMannager = GameObject.FindGameObjectWithTag("GameMannager").GetComponent<DialogueMannager>();
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		combatMannager = GameObject.FindGameObjectWithTag("GameMannager").GetComponent<CombatMannager>();
		difficulty = GameObject.FindGameObjectWithTag("GameMannager").GetComponent<DifficultyMannager>();
		playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
		subject = GameObject.FindGameObjectWithTag("SubjectUI").GetComponent<Image>();
		subjectAnimator = GameObject.FindGameObjectWithTag("SubjectUI").GetComponent<Animator>();
		subjectScript = GameObject.FindGameObjectWithTag("GameMannager").GetComponent<SubjectMannager>();
		dim = GameObject.FindGameObjectWithTag("DimUI").GetComponent<Animator>();

		monster = this;

		subject.sprite = stats.sprite;
		subjectAnimator.SetBool("IsOpen", true);
		dim.SetBool("Dim", true);

		Invoke("StartEvent", 0.1f);
	}

	private void StartEvent()
	{
		dialogue.TriggerDialogue();
		started = true;	
		subjectScript.Activate(monster);
	}

	private void Update()
	{
		if (started == true && dialogueMannager.dialogueOpen == false)
		{
			Invoke("StartCombat", 1f);
			started = false;
		}
		if (stats.health <= 0 && dead == false) MonsterKilled();

		if (dead == true && dialogueMannager.dialogueOpen == false && combatMannager.combatOpen == false)
		{
			dim.SetBool("Dim", false);
			playerController.canMove = true;
			playerStats.inBoss = false;
			Destroy(gameObject);
		}
	}

	private void StartCombat()
	{
		combatMannager.StartCombat(monster);
	}


	public void MonsterKilled()
	{
		playerStats.gold += stats.goldValue * difficulty.multiplyer;
		playerStats.exp += stats.expValue;
		dialogue2.TriggerDialogue();
		subjectAnimator.SetBool("IsOpen", false);
		subjectScript.Deactivate();
		dead = true;
	}
}
