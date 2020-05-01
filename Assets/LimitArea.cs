using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        WarningEngine.instance.EnterArea();
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        WarningEngine.instance.ExitArea();
    }
}
