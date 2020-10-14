using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatMannager : MonoBehaviour
{

	public Animator animator;

	public bool combatOpen;

	private void Start()
	{
		combatOpen = false;
	}

	public void StartCombat()
	{
		animator.SetBool("IsOpen", true);

		combatOpen = true;
	}

}
