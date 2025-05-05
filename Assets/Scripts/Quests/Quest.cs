using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]

public class Quest
{
    public string questName;
    public string description;
    public int pointsRequirement;
    public List <string> tasksToComplete;

    public Quest(string name, string desc, int points, List<string> tasks)
    {
        questName = name;
        description = desc;
        pointsRequirement = points;
        tasksToComplete = tasks;
    }

    public void completeTask(string task)
    {
        if(tasksToComplete.Contains(task))
        {
            tasksToComplete.Remove(task);
            CheckIfCompleted();
        }
    }

    public void CheckIfCompleted()
    {
        if (tasksToComplete.Count == 0)
        {
            QuestManager.Instance.CompleteQuest(questName);
        }
    }
}
