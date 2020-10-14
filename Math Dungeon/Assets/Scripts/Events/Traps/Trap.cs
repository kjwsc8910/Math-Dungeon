using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

	public TrapStats stats;
	public DialogueTrigger dialogue;
	private DialogueMannager dialogueMannager;
	private PlayerController playerController;
	private TrabBoxMannager trapBoxMannager;

	private int x;
	private int y;
	private int z;
	private string q;

	private int random;

	private bool started = false;

	private void Start()
	{
		dialogueMannager = GameObject.FindGameObjectWithTag("GameMannager").GetComponent<DialogueMannager>();
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		trapBoxMannager = GameObject.FindGameObjectWithTag("GameMannager").GetComponent<TrabBoxMannager>();

		random = Random.Range(1, 11);
		x = random;
		random = Random.Range(1, 11);
		y = random;
		random = Random.Range(1, 3);
		if (random == 1)
		{
			q = "+";
			z = x + y;
		}
		if (random == 2)
		{
			q = "*";
			z = x * y;
		}

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
			trapBoxMannager.StartTrap(x, y, z, q);
			started = false;
		}
	}

}
