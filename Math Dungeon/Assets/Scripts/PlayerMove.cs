using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

	private Rigidbody2D rb;
	private Vector3 targetPos;

	private RoomTemplates roomTemplates;
	private GameObject currentRoom;
	private GameObject nextRoom;
	private Collider2D[] colliders;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		roomTemplates = GameObject.FindGameObjectWithTag("GameMannager").GetComponent<RoomTemplates>();
	}
	public void MoveUp()
	{
		targetPos = rb.transform.position + new Vector3(0, 1, 0);

		if ((colliders = Physics2D.OverlapCircleAll(transform.position, 0.25f)).Length > 1)
		{
			foreach (var collider in colliders)
			{
				currentRoom = collider.gameObject;
				if (currentRoom == gameObject) continue;

				for (int i = 0; i < roomTemplates.topRooms.Length; i++)
				{
					if (currentRoom.name == string.Format("{0}(Clone)", roomTemplates.topRooms[i].name) || currentRoom.name == "ALL Tile")
					{
						if ((colliders = Physics2D.OverlapCircleAll(targetPos, 0.25f)).Length > 1)
						{
							foreach (var collider2 in colliders)
							{
								nextRoom = collider2.gameObject;
								if (nextRoom == gameObject) continue;

								for (int i2 = 0; i2 < roomTemplates.bottomRooms.Length; i2++)
								{
									if (nextRoom.name == string.Format("{0}(Clone)", roomTemplates.bottomRooms[i2].name) || nextRoom.name == "ALL Tile")
									{
										rb.MovePosition(targetPos);
									}
								}
							}
						}
					}
				}				
			}
		}
	}

	public void MoveRight()
	{
		targetPos = rb.transform.position + new Vector3(1, 0, 0);
		if ((colliders = Physics2D.OverlapCircleAll(transform.position, 0.25f)).Length > 1)
		{
			foreach (var collider in colliders)
			{
				currentRoom = collider.gameObject;
				if (currentRoom == gameObject) continue;

				for (int i = 0; i < roomTemplates.rightRooms.Length; i++)
				{
					if (currentRoom.name == string.Format("{0}(Clone)", roomTemplates.rightRooms[i].name) || currentRoom.name == "ALL Tile")
					{
						if ((colliders = Physics2D.OverlapCircleAll(targetPos, 0.25f)).Length > 1)
						{
							foreach (var collider2 in colliders)
							{
								nextRoom = collider2.gameObject;
								if (nextRoom == gameObject) continue;

								for (int i2 = 0; i2 < roomTemplates.leftRooms.Length; i2++)
								{
									if (nextRoom.name == string.Format("{0}(Clone)", roomTemplates.leftRooms[i2].name) || nextRoom.name == "ALL Tile")
									{
										rb.MovePosition(targetPos);
									}
								}
							}
						}
					}
				}
			}
		}
	}

	public void MoveDown()
	{
		targetPos = rb.transform.position + new Vector3(0, -1, 0);
		if ((colliders = Physics2D.OverlapCircleAll(transform.position, 0.25f)).Length > 1)
		{
			foreach (var collider in colliders)
			{
				currentRoom = collider.gameObject;
				if (currentRoom == gameObject) continue;

				for (int i = 0; i < roomTemplates.bottomRooms.Length; i++)
				{
					if (currentRoom.name == string.Format("{0}(Clone)", roomTemplates.bottomRooms[i].name) || currentRoom.name == "ALL Tile")
					{
						if ((colliders = Physics2D.OverlapCircleAll(targetPos, 0.25f)).Length > 1)
						{
							foreach (var collider2 in colliders)
							{
								nextRoom = collider2.gameObject;
								if (nextRoom == gameObject) continue;

								for (int i2 = 0; i2 < roomTemplates.topRooms.Length; i2++)
								{
									if (nextRoom.name == string.Format("{0}(Clone)", roomTemplates.topRooms[i2].name) || nextRoom.name == "ALL Tile")
									{
										rb.MovePosition(targetPos);
									}
								}
							}
						}
					}
				}
			}
		}
	}

	public void MoveLeft()
	{
		targetPos = rb.transform.position + new Vector3(-1, 0, 0);
		if ((colliders = Physics2D.OverlapCircleAll(transform.position, 0.25f)).Length > 1)
		{
			foreach (var collider in colliders)
			{
				currentRoom = collider.gameObject;
				if (currentRoom == gameObject) continue;

				for (int i = 0; i < roomTemplates.leftRooms.Length; i++)
				{
					if (currentRoom.name == string.Format("{0}(Clone)", roomTemplates.leftRooms[i].name) || currentRoom.name == "ALL Tile")
					{
						if ((colliders = Physics2D.OverlapCircleAll(targetPos, 0.25f)).Length > 1)
						{
							foreach (var collider2 in colliders)
							{
								nextRoom = collider2.gameObject;
								if (nextRoom == gameObject) continue;

								for (int i2 = 0; i2 < roomTemplates.rightRooms.Length; i2++)
								{
									if (nextRoom.name == string.Format("{0}(Clone)", roomTemplates.rightRooms[i2].name) || nextRoom.name == "ALL Tile")
									{
										rb.MovePosition(targetPos);
									}
								}
							}
						}
					}
				}
			}
		}
	}

}
