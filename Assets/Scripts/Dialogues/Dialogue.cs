using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Dialogue
{

    public String name;
    [TextArea(3, 10)]
    public String[] sentences;
}
