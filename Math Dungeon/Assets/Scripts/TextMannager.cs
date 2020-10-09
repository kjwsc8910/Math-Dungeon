using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMannager : MonoBehaviour
{
    private GameObject textBox;
    private GameObject combatBox;

    void Start()
    {
        textBox = GameObject.FindGameObjectWithTag("TextBox");
        combatBox = GameObject.FindGameObjectWithTag("CombatBox");
    }

    public void ShowText(string _text)
	{

	}
}
