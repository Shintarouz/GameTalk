using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{

    public static QuestManager Instance; 

    public GameObject questMenu;
    public GameObject pointsMenu;
    public GameObject optionsMenu;
    public TextMeshProUGUI pointsText;
    public List<Quest> ActiveQuests = new();
    public List<Quest> CompletedQuests = new();


    private void Awake() // Looks if QuestManager object already exists in the scene
    {
        if ( Instance == null)
        {
            Instance = this;
        }
    } 
    public void taskSetter(string objective)
    {
        foreach ( var quest in ActiveQuests)
            {
                quest.completeTask(objective);
            }
    }

    private void Start()
    {
        DisplayPoints(); // Updates points text at the start 
        DialogueManager.Instance.DisplayQuests();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            DisplayPoints();
            DialogueManager.Instance.DisplayQuests();

            if(pointsMenu)
                {pointsMenu.SetActive(!pointsMenu.activeSelf);}

            if(questMenu)
                {questMenu.SetActive(!questMenu.activeSelf);}
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if(optionsMenu)
                {optionsMenu.SetActive(!optionsMenu.activeSelf);}
        }
    }


    public void PointsChecker()
    {
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();

        if (pointsText.text != playerMovement.scoreTester.ToString())
        {
            DisplayPoints();
        }
    }


    public void DisplayPoints()
    {
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        pointsText.text = playerMovement.scoreTester.ToString();
    }


    public void CompleteQuest(string questName)
    {
        Quest quest = ActiveQuests.Find(q => q.questName == questName);
        if (quest != null)
        {
            CompletedQuests.Add(quest);
            ActiveQuests.Remove(quest);
            // Activate rewards playerMovement.points = ++;
            DialogueManager.Instance.DisplayQuests();
        }
    }



    public bool IsQuestActive(string questName)
    {
        return ActiveQuests.Exists(q => q.questName == questName);
    }


    
    public void AddQuest(Quest newQuest)
    {
        if (questMenu != null)
        {
            if (ActiveQuests.Contains(newQuest) || CompletedQuests.Contains(newQuest)) return;
            ActiveQuests.Add(newQuest);
            DialogueManager.Instance.DisplayQuests();
        }
    }

    public bool IsQuestCompleted(string questName)
    {
        return CompletedQuests.Exists(q => q.questName == questName);
    }
}
