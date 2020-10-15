using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUIMannager : MonoBehaviour
{

	private GameObject ui;
	public Slider healthSlider;
	public TextMeshProUGUI healthName;
	public TextMeshProUGUI healthPots;
	public Slider mannaSlider;
	public TextMeshProUGUI mannaName;
	public TextMeshProUGUI mannaPots;


	private PlayerStats playerStats;


	private void Start()
	{
		ui = GameObject.FindGameObjectWithTag("PlayerUI");
		playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
	}

	private void Update()
	{
		healthSlider.value = playerStats.health;
		healthName.text = "Health - " + playerStats.health.ToString();
		healthPots.text = playerStats.healthPots.ToString();
		mannaSlider.value = playerStats.manna;
		mannaName.text = "Manna - " + playerStats.manna.ToString();
		mannaPots.text = playerStats.mannaPots.ToString();
	}


}
