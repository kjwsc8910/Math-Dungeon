using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	private PlayerMove playerMove;

	[SerializeField]
	private bool canMove = true;

	private float xMove;
	private float yMove;

	private void Start()
	{
		playerMove = GetComponent<PlayerMove>();
	}

	private void Update()
	{

		//Temporary Enable Move
		if (Input.GetKeyDown("space") == true)
		{
			canMove = true;
		}

		//Get Movement Commands
		if (canMove == true)
		{
			xMove = Input.GetAxis("Horizontal");
			yMove = Input.GetAxis("Vertical");

			if (xMove > 0)
			{
				playerMove.MoveRight();
				canMove = false;
			}
			else if (xMove < 0)
			{
				playerMove.MoveLeft();
				canMove = false;
			}

			if (yMove > 0)
			{
				playerMove.MoveUp();
				canMove = false;
			}
			else if (yMove < 0)
			{
				playerMove.MoveDown();
				canMove = false;
			}
		}
	}


}
