using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueMannager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject cont;
    public GameObject choiceOne;
    public GameObject choiceTwo;

    public Animator animator;

    public bool dialogueOpen;
    public int choice;
    private bool needChoice;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
        dialogueOpen = false;
        choice = 0;
    }

    public void StartDialogue(Dialogue dialogue)
	{
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        dialogueOpen = true;

        choice = 0;

        needChoice = dialogue.needChoice;

        choiceOne.GetComponentInChildren<TextMeshProUGUI>().text = dialogue.choiceOneName;

        choiceTwo.GetComponentInChildren<TextMeshProUGUI>().text = dialogue.choiceTwoName;

        sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
            sentences.Enqueue(sentence);
		}

        DisplayNextSentence();
	}

    public void DisplayNextSentence()
	{

		if (sentences.Count == 0)
		{
            EndDialogue();
            return;
		}

        if (sentences.Count == 1 && needChoice == true)
		{
            cont.SetActive(false);
            choiceOne.SetActive(true);
            choiceTwo.SetActive(true);
		}

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
	}

    IEnumerator TypeSentence (string sentence)
	{
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
		{
            dialogueText.text += letter;
            yield return null;
		}
	}

    void EndDialogue()
	{
		cont.SetActive(true);
		choiceOne.SetActive(false);
        choiceTwo.SetActive(false);

        animator.SetBool("IsOpen", false);

        dialogueOpen = false;
    }

    public void selectOne()
	{
        choice = 1;
	}

    public void selectTwo()
	{
        choice = 2;
	}
}
