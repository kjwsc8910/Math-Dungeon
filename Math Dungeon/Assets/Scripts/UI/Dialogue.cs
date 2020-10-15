using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{

	public string name;

	public bool needChoice;
	public string choiceOneName;
	public string choiceTwoName;
	
	[TextArea(3, 10)]
	public string[] sentences;

}
