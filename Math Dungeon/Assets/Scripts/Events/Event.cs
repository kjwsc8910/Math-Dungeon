﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
	private PlayerController playerController;

    private int rand;
    private string eventType;
	private bool eventCompleted;

    private void Start()
    {
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

		eventCompleted = false;

		rand = Random.Range(1, 10);

		if (rand <= 5)
		{
            eventType = "Monster";
		}
		else if (rand <= 8)
		{
			eventType = "Trap";
		}
		else
		{
			eventType = "Item";
		}
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player" && eventCompleted == false)
		{
			Debug.Log(eventType);
			playerController.canMove = false;
			FindObjectOfType<EventMannager>().Event(eventType);
			eventCompleted = true;
		}
	}
} 