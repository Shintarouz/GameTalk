using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaData : MonoBehaviour
{
    public Dictionary<int, string[]> npcDialogues;

    // string[,] story = new string[,]
    // {
    //     {"hoi","ja","nee"},
    //     {"hoi2","ja2","nee2"},
    //     {"hoi3","ja3","nee3"}
    // };
    
    void Awake()
    {
        npcDialogues = new Dictionary<int, string[]>
        {
            {1, new string[] {"Hi! Welcome to the city.","I'm Stewart, nice to meet you.","That's Steve over there!"} },
            {2, new string[] {"2.0", "2.1", "2.2"} }
        };
    }


    // public string[] GetStoryDialogue(int step)
    // {
    //     if (step < 0 || step >= story.GetLength(0))
    //     {
    //         return new string[] {"eind"};
    //     }
    //     return new string[] {story[step, 0], story[step, 1], story[step, 2]};

    // }
    public string[] GetDialogueByNPCID(int npcID)
    {
        if (npcDialogues.ContainsKey(npcID))
        {
            return npcDialogues[npcID];
        }
        else
        {
            return new string[] {"nothing here"};
        }
    }
}
