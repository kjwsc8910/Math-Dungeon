using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyMannager : MonoBehaviour
{

	public int questionLength;
	public int questionMin;
	public int questionMax;
	public float multiplyer;
	public float qteTimer;

	void Awake()
	{
		questionLength = PlayerPrefs.GetInt("qLength");
		questionMin = PlayerPrefs.GetInt("qMin");
		questionMax = PlayerPrefs.GetInt("qMax");
		qteTimer = PlayerPrefs.GetFloat("qteTimer");
	}

	private void Start()
	{
		if (questionLength <= 1) questionLength = 2;
		if (questionMax < 5) questionMax = 5;
		if (questionMin >= questionMax || questionMin <= 1) questionMin = 2;
		if (qteTimer < 2f) qteTimer = 5f;

		PlayerPrefs.SetInt("qLength", questionLength);
		PlayerPrefs.SetInt("qMax", questionMax);
		PlayerPrefs.SetInt("qMin", questionMin);
		PlayerPrefs.SetFloat("qteTimer", qteTimer);

		multiplyer = 1 * (1 + ((((questionMax - questionMin - 2) * (5 / qteTimer)) * (questionLength - 1)) / 5));
	}

}
