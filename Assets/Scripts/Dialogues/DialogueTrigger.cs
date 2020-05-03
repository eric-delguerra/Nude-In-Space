using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue Dialogue;


    public void TriggerDialogue(bool endLvl)
    {
        FindObjectOfType<DialogManager>().StartDialogue(Dialogue, endLvl);
    }

    public void AlienWord(bool endLvl)
    {
        print("Alien");
        Dialogue.sentences.SetValue("Ah Super merci !", 0);
        Dialogue.sentences.SetValue("Voilà ton pantalon !", 1);
        FindObjectOfType<DialogManager>().StartDialogue(Dialogue, endLvl);
    }
}