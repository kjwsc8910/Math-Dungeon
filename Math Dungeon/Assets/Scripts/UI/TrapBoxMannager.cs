using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrapBoxMannager : MonoBehaviour
{

	public Animator animator;
	private PlayerController playerController;
	private PlayerStats playerStats;
	private DifficultyMannager difficulty;

	private string attribute;
	private int strength;

	public TextMeshProUGUI question;
	public TextMeshProUGUI optionOne;
	public TextMeshProUGUI optionTwo;
	public TextMeshProUGUI optionThree;
	public TextMeshProUGUI optionFour;

	public Slider timerSlider;

	private int correctAns;
	private int random;

	public bool isTrapBoxOpen;

	[SerializeField]
	private float time;

	private bool timeOut;

	private void Start()
	{
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
		difficulty = GameObject.FindGameObjectWithTag("GameMannager").GetComponent<DifficultyMannager>();
		isTrapBoxOpen = false;
		time = 0f;
		timeOut = false;

	}

	private void Update()
	{
		if (time > difficulty.qteTimer) time = difficulty.qteTimer;
		timerSlider.highValue = difficulty.qteTimer;
		timerSlider.value = difficulty.qteTime - time;

		if (isTrapBoxOpen == true) time += Time.deltaTime;
		if (time >= difficulty.qteTimer && timeOut == false)
		{
			timeOut = true;
			Incorrect();
		}
	}

	public void StartTrap(string _question, float _ans, string _attribute, int _strength)
	{

		attribute = _attribute;
		strength = _strength;
		time = 0f;
		timeOut = false;

		question.text = _question;

		correctAns = Random.Range(1, 5);

		random = Random.Range(1, 3);
		if (random == 1) optionOne.text = "It is " + (_ans + Random.Range(1, 11)); else optionOne.text = "It is " + (_ans - Random.Range(1, 11));

		random = Random.Range(1, 3);
		if (random == 1) optionTwo.text = "It is " + (_ans + Random.Range(1, 11)); else optionTwo.text = "It is " + (_ans - Random.Range(1, 11));

		random = Random.Range(1, 3);
		if (random == 1) optionThree.text = "It is " + (_ans + Random.Range(1, 11)); else optionThree.text = "It is " + (_ans - Random.Range(1, 11));

		random = Random.Range(1, 3);
		if (random == 1) optionFour.text = "It is " + (_ans + Random.Range(1, 11)); else optionFour.text = "It is " + (_ans - Random.Range(1, 11));

		if (correctAns == 1) optionOne.text = "It is " + _ans;
		if (correctAns == 2) optionTwo.text = "It is " + _ans;
		if (correctAns == 3) optionThree.text = "It is " + _ans;
		if (correctAns == 4) optionFour.text = "It is " + _ans;

		animator.SetBool("IsOpen", true);
		isTrapBoxOpen = true;
	}

	private void Correct()
	{
		animator.SetBool("IsOpen", false);
		isTrapBoxOpen = false;
		playerController.canMove = true;
		Debug.Log("Correct");
	}

	private void Incorrect()
	{
		animator.SetBool("IsOpen", false);
		isTrapBoxOpen = false;
		playerController.canMove = true;
		if (attribute == "Health") playerStats.health -= strength;
		Debug.Log("Wrong");
	}

	public void SelectOne()
	{
		if (correctAns != 1)
		{
			Incorrect();
			return;
		}
		Correct();
	}

	public void SelectTwo()
	{
		if (correctAns != 2)
		{
			Incorrect();
			return;
		}
		Correct();
	}

	public void SelectThree()
	{
		if (correctAns != 3)
		{
			Incorrect();
			return;
		}
		Correct();
	}
	
	public void SelectFour()
	{
		if (correctAns != 4)
		{
			Incorrect();
			return;
		}
		Correct();
	}
}
