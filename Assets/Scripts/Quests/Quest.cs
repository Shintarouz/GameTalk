using System;

[Serializable]

public class Quest
{
    public string questName;
    public string description;
    public int pointsRequirement;

    public Quest(string name, string desc, int points)
    {
        pointsRequirement = points;
        questName = name;
        description = desc;
    }
}
