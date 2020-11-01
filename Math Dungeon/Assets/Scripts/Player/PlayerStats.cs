using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
	public float maxHealth;
	public float health;
	public int healthPots;

	public float maxManna;
	public float manna;
	public int mannaPots;

	public int attack;
	public float critRate;
	public float critDamage;

	public int level;
	public float exp;

	public float gold;

	public bool inBoss;

	private float highScore;

	private bool dead;

	private PlayerController playerController;
	public MusicPlayer deathScreenMusic;
	private AudioMannager mainMusic;

	public Animator playerSubjectAnim;
	public GameObject deadScreen;
	public TextMeshProUGUI levelText;
	public TextMeshProUGUI goldText;

	private void Start()
	{
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		mainMusic = GameObject.FindGameObjectWithTag("GameMannager").GetComponent<AudioMannager>();

		inBoss = false;
		dead = false;
	}

	private void Update()
	{
		if (health > maxHealth) health = maxHealth;
		if (manna > maxManna) manna = maxManna;
		if (health <= 0) Dead();
	}

	private void Dead()
	{
		highScore = PlayerPrefs.GetFloat("HighScore");
		if (gold > highScore) highScore = gold;
		PlayerPrefs.SetFloat("HighScore", gold);
		playerController.canMove = false;
		levelText.text = "Level: " + level;
		goldText.text = "Gold: " + gold;
		deadScreen.SetActive(true);

		deathScreenMusic.playMusic = true;
		mainMusic.playMusic = false;

		if (dead == true) return;
		dead = true;
		playerSubjectAnim.ResetTrigger("hit");
		playerSubjectAnim.SetBool("IsOpen", false);
		mainMusic.StopAllAudio();
	}
}
