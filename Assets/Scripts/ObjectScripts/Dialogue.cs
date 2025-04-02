using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Dialogue
{
    public string[] dialogue;
    public (string, string) answers;

    public Dialogue(string[] d, (string, string) a){
        dialogue = d;
        answers = a;
    }
}
