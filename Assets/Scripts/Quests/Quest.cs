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
    public int pointsRequirement;

    public Quest(string name, string desc, int points)
    {
        pointsRequirement = points;
        questName = name;
        description = desc;
        isCompleted = false;
    }
}
