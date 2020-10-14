using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	private PlayerMove playerMove;

	public bool canMove = true;
	private bool keyHeld = false;

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
				if (keyHeld == false)
				{
					playerMove.MoveRight();
					keyHeld = true;
				}
			}
			else if (xMove < 0)
			{
				if (keyHeld == false)
				{
					playerMove.MoveLeft();
					keyHeld = true;
				}
			}

			if (yMove > 0)
			{
				if (keyHeld == false)
				{
					playerMove.MoveUp();
					keyHeld = true;
				}
			}
			else if (yMove < 0)
			{
				if (keyHeld == false)
				{
					playerMove.MoveDown();
					keyHeld = true;
				}
			}

			if (xMove == 0 && yMove == 0)
			{
				keyHeld = false;
			}
		}
	}


}
