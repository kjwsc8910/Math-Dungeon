using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

	public MonsterStats stats;
	public DialogueTrigger dialogue;
	private DialogueMannager dialogueMannager;
	private PlayerController playerController;

	private bool started = false;

	private void Start()
	{
		dialogueMannager = GameObject.FindGameObjectWithTag("GameMannager").GetComponent<DialogueMannager>();
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		Invoke("StartEvent", 0.1f);
	}

	private void StartEvent()
	{
		dialogue.TriggerDialogue();
		started = true;
	}

	private void FixedUpdate()
	{
		if (started == true && dialogueMannager.dialogueOpen == false)
		{
			playerController.canMove = true;
			started = false;
		}
	}


}
