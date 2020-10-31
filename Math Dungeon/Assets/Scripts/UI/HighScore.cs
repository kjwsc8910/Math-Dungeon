using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{

    private float highScore;
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        highScore = PlayerPrefs.GetFloat("HighScore");
        highScoreText.text = "High Score: " + highScore;
    }

}
