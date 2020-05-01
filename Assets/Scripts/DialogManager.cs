using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{

    public TextMeshProUGUI textName;
    public TextMeshProUGUI dialogueText;
    private Queue<String> sentences;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        textName.text = dialogue.name;
        sentences.Clear();

        foreach (String sentence in dialogue.sentences)
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

        String sentence = sentences.Dequeue();
        StopAllCoroutines();    
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(String sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    private void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        GameObject.Find("Player").gameObject.GetComponent<PlayerController>().enabled = true;
    }
}
