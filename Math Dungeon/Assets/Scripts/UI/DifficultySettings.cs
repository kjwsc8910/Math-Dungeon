using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DifficultySettings : MonoBehaviour
{

    public InputField qLengthInput;
    public InputField qMinInput;
    public InputField qMaxInput;
    public InputField qteTimeInput;

    public TextMeshProUGUI multiplyerText;

    private int questionLength;
    private int questionMax;
    private int questionMin;
    private float qteTimer;
    private float multiplyer;


    void Start()
    {
        if (PlayerPrefs.GetInt("qLength") <= 1) PlayerPrefs.SetInt("qLength", 2);
        if (PlayerPrefs.GetInt("qMax") < 5) PlayerPrefs.SetInt("qMax", 5);
        if (PlayerPrefs.GetInt("qMin") >= PlayerPrefs.GetInt("qMax") || PlayerPrefs.GetInt("qMin") <= 1) PlayerPrefs.SetInt("qMin", 2);
        if (PlayerPrefs.GetFloat("qteTimer") < 2f) PlayerPrefs.SetFloat("qteTimer", 5f);

        questionLength = PlayerPrefs.GetInt("qLength");
        questionMax = PlayerPrefs.GetInt("qMax");
        questionMin = PlayerPrefs.GetInt("qMin");
        qteTimer = PlayerPrefs.GetFloat("qteTimer");

        qLengthInput.text = questionLength.ToString();
        qMaxInput.text = questionMax.ToString();
        qMinInput.text = questionMin.ToString();
        qteTimeInput.text = qteTimer.ToString();

        multiplyer = 1 * (1 + ((((questionMax - questionMin - 2) * (5 / qteTimer)) * (questionLength - 1)) / 5));

        multiplyerText.text = "X" + multiplyer;

    }

    void Update()
    {
        
    }

    public void ChangeDifficulty()
	{
        questionLength = int.Parse(qLengthInput.text);
        questionMax = int.Parse(qMaxInput.text);
        questionMin = int.Parse(qMinInput.text);
        qteTimer = float.Parse(qteTimeInput.text);

        PlayerPrefs.SetInt("qLength", questionLength);
        PlayerPrefs.SetInt("qMax", questionMax);
        PlayerPrefs.SetInt("qMin", questionMin);
        PlayerPrefs.SetFloat("qteTimer", qteTimer);

        if (PlayerPrefs.GetInt("qLength") <= 1) PlayerPrefs.SetInt("qLength", 2);
        if (PlayerPrefs.GetInt("qMax") < 5) PlayerPrefs.SetInt("qMax", 5);
        if (PlayerPrefs.GetInt("qMin") >= PlayerPrefs.GetInt("qMax") || PlayerPrefs.GetInt("qMin") <= 1) PlayerPrefs.SetInt("qMin", 2);
        if (PlayerPrefs.GetFloat("qteTimer") < 2f) PlayerPrefs.SetFloat("qteTimer", 5f);

        questionLength = PlayerPrefs.GetInt("qLength");
        questionMax = PlayerPrefs.GetInt("qMax");
        questionMin = PlayerPrefs.GetInt("qMin");
        qteTimer = PlayerPrefs.GetFloat("qteTimer");

        qLengthInput.text = questionLength.ToString();
        qMaxInput.text = questionMax.ToString();
        qMinInput.text = questionMin.ToString();
        qteTimeInput.text = qteTimer.ToString();

        multiplyer = 1 * (1 + ((((questionMax - questionMin - 2) * (5 / qteTimer)) * (questionLength - 1)) / 5));

        multiplyerText.text = "X" + multiplyer;
    }


}
