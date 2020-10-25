using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubjectMannager : MonoBehaviour
{

    public Slider health;
	public Monster monster;
    private bool active;

	private void Start()
	{
		health.gameObject.SetActive(false);
		active = false;
	}

	public void Activate(Monster _monster)
	{
		monster = _monster;
		health.gameObject.SetActive(true);
		active = true;
		health.maxValue = monster.stats.health;
	}

	public void Deactivate()
	{
		health.gameObject.SetActive(false);
		active = false;
	}

	void Update()
    {
		if (active == true)
		{
			health.value = monster.stats.health;
		}
    }
}
