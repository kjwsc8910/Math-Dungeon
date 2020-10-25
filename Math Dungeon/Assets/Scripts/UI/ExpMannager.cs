using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpMannager : MonoBehaviour
{

    private PlayerStats playerStats;
    private PlayerController playerController;
    private CombatMannager combatMannager;
    private DialogueMannager dialogueMannager;
    private TrapBoxMannager trapBoxMannager;

    public Slider exp;
    public TextMeshProUGUI level;
    public TextMeshProUGUI gold;

    private Animator levelUpAnim;
    public TextMeshProUGUI maxHealth;
    public TextMeshProUGUI maxManna;
    public TextMeshProUGUI attack;
    public TextMeshProUGUI critRate;
    public TextMeshProUGUI critDamage;

    public float maxExp;
    private bool levelUp;
    private int statUps;

    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        playerController = GameObject.FindGameObjectWithTag("GameMannager").GetComponent<PlayerController>();
        combatMannager = GameObject.FindGameObjectWithTag("GameMannager").GetComponent<CombatMannager>();
        dialogueMannager = GameObject.FindGameObjectWithTag("GameMannager").GetComponent<DialogueMannager>();
        trapBoxMannager = GameObject.FindGameObjectWithTag("GameMannager").GetComponent<TrapBoxMannager>();
        levelUpAnim = GameObject.FindGameObjectWithTag("LevelUpUI").GetComponent<Animator>();


        levelUpAnim.SetBool("IsOpen", false);
        levelUp = false;
        statUps = 0;
    }

    void Update()
    {
		if (playerStats.exp >= maxExp)
		{
            playerStats.exp -= maxExp;
            playerStats.level += 1;
            statUps += 1;
            levelUp = true;

            maxExp *= 1.2f;
		}

        exp.maxValue = maxExp;
        exp.value = playerStats.exp;

        gold.text = "Gold: " + playerStats.gold.ToString() + "g";

        level.text = "Level: " + playerStats.level.ToString();

        if (combatMannager.combatOpen == false && dialogueMannager.dialogueOpen == false && trapBoxMannager.isTrapBoxOpen == false && levelUp == true) LevelUp();

        maxHealth.text = "Max Health: " + playerStats.maxHealth.ToString();
        maxManna.text = "Max Manna: " + playerStats.maxManna.ToString();
        attack.text = "Attack: " + playerStats.attack.ToString();
        critRate.text = "Crit Rate: " + playerStats.critRate.ToString() + "%";
        critDamage.text = "Crit Damage: " + playerStats.critDamage.ToString() + "%";

        if (statUps <= 0) levelUpAnim.SetBool("IsOpen", false);
    }

    private void LevelUp()
	{
        levelUpAnim.SetBool("IsOpen", true);
	}

    public void StatUp(string _stat)
	{
        if (statUps <= 0) return;

        if (_stat == "maxHealth")
        {
            playerStats.maxHealth += 5;
            playerStats.health += 5;
        }
        if (_stat == "maxManna")
        {
            playerStats.maxManna += 5;
            playerStats.manna += 5;
        }
        if (_stat == "attack") playerStats.attack += 2;
        if (_stat == "critRate") playerStats.critRate += 2.5f;
        if (_stat == "critDamage") playerStats.critDamage += 5f;

        statUps -= 1;
	}
}
