using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class Quest
{
    public string questName;
    public string description;
    public bool isCompleted;

    public Quest(string name, string desc)
    {
        questName = name;
        description = desc;
        isCompleted = false;
    }
}
