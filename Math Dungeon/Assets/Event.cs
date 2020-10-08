using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    private int rand;
    private string EventType;

    private void Start()
    {
		rand = Random.Range(1, 10);

		if (rand <= 5)
		{
            EventType = "Monster";
		}
		else if (rand <= 8)
		{
			EventType = "Trap";
		}
		else
		{
			EventType = "Item";
		}
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			Debug.Log(EventType);
		}
	}


} 
