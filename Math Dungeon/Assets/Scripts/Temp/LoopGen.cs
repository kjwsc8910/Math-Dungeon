using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopGen : MonoBehaviour
{

    public GameObject startDung;

    [SerializeField]
    private float time;

    void Start()
    {
        time = 0f;
        spawn();
    }

    void Update()
	{

        time += Time.deltaTime;

		if (time >= 4 && time <= 4.5)
		{
            destroy();
		}

		if (time >= 5.5)
		{
            spawn();
            time = 0f;
		}
	}

    void destroy()
	{
        Destroy(GameObject.FindGameObjectWithTag("Dungeon"));
        Destroy(GameObject.FindGameObjectWithTag("EndRoom"));
	}

    void spawn()
	{
        Instantiate(startDung, transform.position, startDung.transform.rotation);
    }

}
