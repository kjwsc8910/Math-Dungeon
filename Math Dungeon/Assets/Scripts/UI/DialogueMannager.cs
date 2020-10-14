using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueMannager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;

    public bool dialogueOpen;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
        dialogueOpen = false;
    }

    public void StartDialogue(Dialogue dialogue)
	{
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        dialogueOpen = true;

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
        animator.SetBool("IsOpen", false);

        dialogueOpen = false;
    }
}
