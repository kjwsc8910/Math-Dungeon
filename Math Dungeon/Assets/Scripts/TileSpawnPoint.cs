using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawnPoint : MonoBehaviour
{

	public int openingDirection;
	//1 - Top Door
	//2 - Right Door
	//3 - Bottom Door
	//4 - Left Door

	private RoomTemplates templates;
	private GameObject dungeon;
	private int rand;
	private bool spawned = false;

	void Start()
	{
		templates = GameObject.FindGameObjectWithTag("GameMannager").GetComponent<RoomTemplates>();
		dungeon = GameObject.FindGameObjectWithTag("Dungeon");
		Invoke("Spawn", 0.1f);
	}

	void Spawn()
	{
		if (spawned == false)
		{
			if (openingDirection == 1)
			{
				//Spawn room with Top Door
				rand = Random.Range(0, templates.topRooms.Length);
				var instance = Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
				instance.transform.parent = dungeon.transform;
			}
			else if (openingDirection == 2)
			{
				//Spawn room with Right Door
				rand = Random.Range(0, templates.rightRooms.Length);
				var instance = Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
				instance.transform.parent = dungeon.transform;
			}
			else if (openingDirection == 3)
			{
				//Spawn room with Bottom Door
				rand = Random.Range(0, templates.bottomRooms.Length);
				var instance = Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
				instance.transform.parent = dungeon.transform;
			}
			else if (openingDirection == 4)
			{
				//Spawn room with Left Door
				rand = Random.Range(0, templates.leftRooms.Length);
				var instance = Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
				instance.transform.parent = dungeon.transform;
			}
			spawned = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("SpawnPoint"))
		{
			if(other.GetComponent<TileSpawnPoint>().spawned == false && spawned == false)
			{
				Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
				Destroy(gameObject);
			}
			spawned = true;
		}
	}

}
