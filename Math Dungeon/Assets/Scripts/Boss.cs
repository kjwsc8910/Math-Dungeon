﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public GameObject dungeon;
    private RoomTemplates roomTemplates;
    private DifficultyMannager difficulty;

    private bool started;
    private bool completed;

    private Vector3 target;

	private void Start()
	{ 
        roomTemplates = GameObject.FindGameObjectWithTag("GameMannager").GetComponent<RoomTemplates>();
        difficulty = GameObject.FindGameObjectWithTag("GameMannager").GetComponent<DifficultyMannager>();

        started = false;
        completed = false;
	}

    void Update()
    {
        if (started == true && FindObjectOfType<PlayerStats>().inBoss == false && completed == false) ClearDungeon();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player" && completed == false)
		{
            FindObjectOfType<PlayerStats>().inBoss = true;
            difficulty.questionMax *= 2;
            difficulty.questionMin *= 2;
            difficulty.questionLength += 1;
            FindObjectOfType<EventMannager>().BossEvent();
            started = true;
		}
    }

    public void ClearDungeon()
	{
        completed = true;
        difficulty.questionLength -= 1;
        Destroy(GameObject.FindGameObjectWithTag("Dungeon"));
        Invoke("NewDungeon", 0.1f);
	}

    private void NewDungeon()
	{
        roomTemplates.waitTime = 3f;
        roomTemplates.spawnedBoss = false;
        roomTemplates.rooms.Clear();
        target = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, Camera.main.transform.position.z);
        Camera.main.GetComponent<FollowCam>().Move(target);
        Instantiate(dungeon, transform.position, dungeon.transform.rotation);
        Destroy(gameObject);
	}

}
