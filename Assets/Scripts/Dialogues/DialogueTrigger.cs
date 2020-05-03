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
}
