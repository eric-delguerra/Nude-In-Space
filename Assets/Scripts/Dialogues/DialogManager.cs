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
    public LevelLoader levelLoader;

    public Animator animator = null;
    public GameObject dialogueZone;

    private bool loadNext;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        dialogueZone.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue, bool nextLvl)
    {
        loadNext = nextLvl;
        // animator.SetBool("IsOpen", true);
        dialogueZone.SetActive(true);
        
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
            if (loadNext)
            {
                StartCoroutine(NextLevel());
            }

            EndDialogue();
            return;
        }

        String sentence = sentences.Dequeue();
        StopAllCoroutines();    
        StartCoroutine(TypeSentence(sentence));
    }

    private IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(3f);
        levelLoader.GetComponent<LevelLoader>().loadNextLevel();
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
        StartCoroutine(VolumeHigh());
        // animator.SetBool("IsOpen", false);
        GameObject.Find("Player").gameObject.GetComponent<PlayerController>().enabled = true;
        dialogueZone.SetActive(false);
    }
    
    private IEnumerator VolumeHigh()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().volume += 0.2f;
        yield return new WaitForSeconds(3);
    }
}
