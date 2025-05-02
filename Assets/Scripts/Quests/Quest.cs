using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]

public class Quest
{
    public string questName;
    public string description;
    public int pointsRequirement;
    public bool completed;
    public List <string> tasksToComplete;

    public Quest(string name, string desc, int points, List<string> tasks)
    {
        questName = name;
        description = desc;
        pointsRequirement = points;
        completed = false;
        tasksToComplete = tasks;
    }

    public void completeTask(string task)
    {
        if(tasksToComplete.Contains(task))
        {
            tasksToComplete.Remove(task);
        }
    }
}
