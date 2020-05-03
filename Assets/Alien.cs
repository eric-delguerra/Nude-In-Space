using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{

    private Transform alienPos;
    
    // Start is called before the first frame update
    void Start()
    {
        alienPos = transform;
    }

    public Transform GetAlienPos()
    {
        return alienPos;
    }
}
