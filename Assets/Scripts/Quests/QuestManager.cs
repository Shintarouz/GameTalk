using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> activeQuests = new();
    public List<Quest> completedQuests = new();



   public void CompleteQuest(string questName)
    {
        Quest quest = activeQuests.Find(q => q.questName == questName);
        if (quest != null)
        {
            Debug.Log("+5 coins"); // mag weg
            quest.isCompleted = true;
            completedQuests.Add(quest);
            activeQuests.Remove(quest);
            DialogueManager.instance.DisplayQuests();
        }
    }



    public bool IsQuestActive(string questName)
    {
        return activeQuests.Exists(quest => quest.questName == questName);
    }


    
    public void AddQuest(Quest newQuest)
    {
        if (activeQuests.Contains(newQuest) || completedQuests.Contains(newQuest)) return;
        activeQuests.Add(newQuest);
        DialogueManager.instance.DisplayQuests();
        Debug.Log($"New Quest: {newQuest.questName}"); // mag weg
    }


    // To start a quest use -> StartQuest("The Name of the quest","The Description of the quest"); 
    // // Starts a quest depending on the name and description, if quest exists it returns.
    // public void StartQuest(string questName, string questDescription)
    // {
    //     if (IsQuestActive(questName))
    //     {
    //         return;
    //     }
    //     Quest newQuest = new(questName, questDescription);
    //     AddQuest(newQuest);
    // }



    // public void RemoveQuest(string questName)
    // {
    //     Quest questToRemove = activeQuests.Find(q => q.questName == questName);
    //     if (questToRemove != null)
    //     {
    //         activeQuests.Remove(questToRemove);
    //         Debug.Log($"Quest Removed: {questToRemove.questName}"); // mag weg
    //         DialogueManager.instance.DisplayQuest();
    //     }
    //     else
    //     {
    //         Debug.Log($"Quest not found: {questName}"); // mag weg
    //     }
    // }


    // public void NPCQuestCompleter(int npcID)
    // {
    //     // Checks the npcID and completes the right quest
    //     switch (npcID)
    //     {
    //         case 1:
    //             CompleteQuest("quest1");
    //             break;
            
    //         case 2:
    //             CompleteQuest("quest2");
    //             break;
    //     }
    // }



    // public void NPCQuestPicker(int npcID)
    // {
    //     switch (npcID)
    //     {
    //         // Takes in npcID, and will Start and Display the Quest
    //         case 1:
    //         if (!IsQuestActive("quest1"))
    //         {
    //             StartQuest("quest1", "Talk to John at the Library");
    //             DialogueManager.instance.DisplayQuest();
    //         }
    //         else
    //         {
    //             RemoveQuest("quest1");
    //         }
    //         break;


    //         case 2: 
    //         if (!IsQuestActive("quest2"))
    //         {
    //             StartQuest("quest2","Talk to Stewart at the Park");
    //             DialogueManager.instance.DisplayQuest();
    //         }
    //         else
    //         {
    //             RemoveQuest("quest2");
    //         }
    //         break;


    //         default:
    //         Debug.Log("broke"); // mag weg
    //         break;
            
    //     }
    // }
}
