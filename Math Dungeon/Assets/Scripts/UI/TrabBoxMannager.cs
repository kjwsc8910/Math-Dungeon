using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrabBoxMannager : MonoBehaviour
{

	public Animator animator;
	private PlayerController playerController;

	public TextMeshProUGUI question;
	public TextMeshProUGUI optionOne;
	public TextMeshProUGUI optionTwo;
	public TextMeshProUGUI optionThree;
	public TextMeshProUGUI optionFour;

	private int correctAns;

	public bool isTrapBoxOpen;

	private void Start()
	{
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		isTrapBoxOpen = false;
	}

	public void StartTrap(int x, int y, int z, string q)
	{	
		question.text = ("What is " + x + q + y + "? " + z);
		correctAns = Random.Range(1, 4);
		optionOne.text = ("It is " + Random.Range(1, 100));
		optionTwo.text = ("It is " + Random.Range(1, 100));
		optionThree.text = ("It is " + Random.Range(1, 100));
		optionFour.text = ("It is "+ Random.Range(1, 100));

		if (correctAns == 1) optionOne.text = ("It is " + z);
		if (correctAns == 2) optionTwo.text = ("It is " + z);
		if (correctAns == 3) optionThree.text = ("It is " + z);
		if (correctAns == 4) optionFour.text = ("It is " + z);

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
