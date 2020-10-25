using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMannager : MonoBehaviour
{

	public GameObject[] monsters;
	public GameObject[] traps;
	public GameObject[] items;
	public GameObject[] bossArray;

	private int random;
	private GameObject selection;

	public void Event(string eventType)
	{
		if (eventType == "Monster")
		{
			MonsterEvent();
		}
		else if (eventType == "Trap")
		{
			TrapEvent();
		}
		else if (eventType == "Item")
		{
			ItemEvent();
		}
	}

	public void MonsterEvent()
	{
		random = Random.Range(0, monsters.Length);
		selection = monsters[random];

		Instantiate(selection);
	}

	public void TrapEvent()
	{
		random = Random.Range(0, traps.Length);
		selection = traps[random];

		Instantiate(selection);
	}

	public void ItemEvent()
	{
		random = Random.Range(0, items.Length);
		selection = items[random];

		Instantiate(selection);

	}

	public void BossEvent()
	{
		random = Random.Range(0, bossArray.Length);
		selection = bossArray[random];

		Instantiate(selection);
	}
}
