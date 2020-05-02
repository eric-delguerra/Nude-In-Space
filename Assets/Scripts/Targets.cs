using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{

    public String Name;

    public Vector2 targetPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
    }

 
}
