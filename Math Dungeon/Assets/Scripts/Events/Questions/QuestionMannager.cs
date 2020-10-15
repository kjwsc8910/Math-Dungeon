using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMannager : MonoBehaviour
{

	private float temp;

	public void Addition(int length, int min, int max, out string question, out float ans)
	{
		ans = 0f;

		question = "What is ";

		for (int i = 0; i < length; i++)
		{
			temp = Random.Range(min,max);
			question += temp;
			if (i < length - 1) question = question += " + ";
			ans += temp;
		}
	}

	public void Subtraction(int length, int min, int max, out string question, out float ans)
	{
		ans = 0f;

		question = "What is ";

		for (int i = 0; i < length; i++)
		{
			temp = Random.Range(min, max);
			question += temp;
			if (i < length - 1) question = question += " - ";
			if (i == 0) ans = temp;
			else ans -= temp;
		}
	}

}
