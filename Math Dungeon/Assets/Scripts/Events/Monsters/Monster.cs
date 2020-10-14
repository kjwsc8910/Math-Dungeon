using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

	public MonsterStats stats;
	public DialogueTrigger dialogue;
	private DialogueMannager dialogueMannager;
	private PlayerController playerController;
	private CombatMannager combatMannager;

	private bool started = false;

	private void Start()
	{
		dialogueMannager = GameObject.FindGameObjectWithTag("GameMannager").GetComponent<DialogueMannager>();
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		combatMannager = GameObject.FindGameObjectWithTag("GameMannager").GetComponent<CombatMannager>();
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
	}

	private void StartCombat()
	{
		combatMannager.StartCombat();
	}
}
