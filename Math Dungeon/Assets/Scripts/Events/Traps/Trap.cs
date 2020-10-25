using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trap : MonoBehaviour
{

	public TrapStats stats;
	public DialogueTrigger dialogue;
	private DialogueMannager dialogueMannager;
	private TrapBoxMannager trapBoxMannager;
	private QuestionMannager questionMannager;
	private DifficultyMannager difficulty;
	private Animator dim;
	private Animator subjectAnim;
	private Image subjectImage;

	private string question;
	private float ans;
	private int random;

	private bool started = false;

	private void Start()
	{
		dialogueMannager = GameObject.FindGameObjectWithTag("GameMannager").GetComponent<DialogueMannager>();
		trapBoxMannager = GameObject.FindGameObjectWithTag("GameMannager").GetComponent<TrapBoxMannager>();
		questionMannager = GameObject.FindGameObjectWithTag("GameMannager").GetComponent<QuestionMannager>();
		difficulty = GameObject.FindGameObjectWithTag("GameMannager").GetComponent<DifficultyMannager>();
		dim = GameObject.FindGameObjectWithTag("DimUI").GetComponent<Animator>();
		subjectAnim = GameObject.FindGameObjectWithTag("SubjectUI").GetComponent<Animator>();
		subjectImage = GameObject.FindGameObjectWithTag("SubjectUI").GetComponent<Image>();

		dim.SetBool("Dim", true);
		subjectAnim.SetBool("Center", true);
		subjectImage.sprite = stats.sprite;
		Invoke("StartEvent", 0.1f);
	}

	private void StartEvent()
	{	
		subjectAnim.SetBool("IsOpen", true);
		dialogue.TriggerDialogue();
		started = true;
	}

	private void Update()
	{
		if (started == true && dialogueMannager.dialogueOpen == false)
		{
			started = false;
			random = Random.Range(1, 3);
			if (random == 1) questionMannager.Addition(difficulty.questionLength, difficulty.questionMin, difficulty.questionMax, out question, out ans);
			if (random == 2) questionMannager.Subtraction(difficulty.questionLength, difficulty.questionMin, difficulty.questionMax, out question, out ans);
			trapBoxMannager.StartTrap(question, ans, stats.attribute, stats.strength);
			dim.SetBool("Dim", false);
			subjectAnim.SetBool("IsOpen", false);
			subjectAnim.SetBool("Center", false);
			Destroy(gameObject);
		}
	}

}
