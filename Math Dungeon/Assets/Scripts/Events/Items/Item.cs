using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{

	public ItemStats itemStats;
	public DialogueTrigger dialogue;
	public DialogueTrigger dialogue2;
	public DialogueTrigger dialogue3;
	private DialogueMannager dialogueMannager;
	private PlayerController playerController;
	private PlayerStats playerStats;
	private Animator dim;
	private Animator subjectAnim;
	private Image subjectImage;

	private bool started = false;
	private bool restarted = false;

	private void Start()
	{
		dialogueMannager = GameObject.FindGameObjectWithTag("GameMannager").GetComponent<DialogueMannager>();
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
		dim = GameObject.FindGameObjectWithTag("DimUI").GetComponent<Animator>();
		subjectAnim = GameObject.FindGameObjectWithTag("SubjectUI").GetComponent<Animator>();
		subjectImage = GameObject.FindGameObjectWithTag("SubjectUI").GetComponent<Image>();

		dim.SetBool("Dim", true);
		subjectAnim.SetBool("Center", true);
		subjectImage.sprite = itemStats.sprite;
		Invoke("StartEvent", 0.1f);
	}

	private void StartEvent()
	{
		subjectAnim.SetBool("IsOpen", true);
		dialogue.TriggerDialogue();
		started = true;
		restarted = false;
	}

	private void Update()
	{
		if (started == true && dialogueMannager.dialogueOpen == false)
		{
			if (itemStats.name == "Health Potion" && restarted == false) healthPotion();
			if (itemStats.name == "Manna Potion" && restarted == false) mannaPotion();
			started = false;
		}
		if (restarted == true && dialogueMannager.dialogueOpen == false)
		{
			dim.SetBool("Dim", false);
			subjectAnim.SetBool("IsOpen", false);
			subjectAnim.SetBool("Center", false);
			playerController.canMove = true;
			Destroy(gameObject);
		}
	}

	private void healthPotion()
	{
		if (dialogueMannager.choice == 1)
		{
			dialogue2.TriggerDialogue();
			playerStats.healthPots += 1;
			started = false;
			restarted = true;
		}
		if (dialogueMannager.choice == 2)
		{
			dialogue3.TriggerDialogue();
			playerStats.health += 20;
			started = false;
			restarted = true;
		}
	}

	private void mannaPotion()
	{
		if (dialogueMannager.choice == 1)
		{
			dialogue2.TriggerDialogue();
			playerStats.mannaPots += 1;
			started = false;
			restarted = true;
		}
		if (dialogueMannager.choice == 2)
		{
			dialogue3.TriggerDialogue();
			playerStats.manna += 15;
			started = false;
			restarted = true;
		}
	}
}
