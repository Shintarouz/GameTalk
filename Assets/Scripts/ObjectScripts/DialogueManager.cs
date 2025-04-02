using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    public GameObject contButton;
    public TextMeshProUGUI missionText;

    private Queue<string> sentences;
    public bool isDialogueActive = false;


    private DiaData diadata;
    private QuestManager questManager;
    private Quest currentQuest;



    void Awake()
    {
        if ( instance == null )
        {
            instance = this;
        }
        sentences = new Queue<string>();
        dialoguePanel.SetActive(false);
        diadata = FindObjectOfType<DiaData>();
        questManager = FindObjectOfType<QuestManager>();
    }


    public void StartDialogue(string npcName, int npcID, Quest quest)
    {
        if (isDialogueActive) return;

        currentQuest = quest;
        isDialogueActive = true;
        dialoguePanel.SetActive(true);
        nameText.text = npcName;
        sentences.Clear();

        string[] dialogue = diadata.GetDialogueByNPCID(npcID);
        // string[] dialogue = diadata.GetStoryDialogue()
        foreach(string sentence in dialogue)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        // PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        if(sentences.Count == 0)
        {
            // playerMovement.scoreTester += 5;
            EndDialogue();
            return;
        }
        
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        dialogueText.text = "";
        StartCoroutine(Typing(sentence));
    }



    IEnumerator Typing(string sentence)
    {
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }



    public void EndDialogue()
    {
        
        isDialogueActive = false;
        dialoguePanel.SetActive(false);
        if (currentQuest == null) return;
        questManager.AddQuest(currentQuest);
        currentQuest = null;        
    }

    public void DisplayQuests()
    {
        if (questManager.activeQuests.Count == 0)
        {
            missionText.text = "No Active Quests";
            return;
        }
        
        missionText.text = "";

        foreach (Quest q in questManager.activeQuests)
        {
            missionText.text += $"\nQuest: {q.questName}\nObjective: {q.description}\nStatus: {(q.isCompleted ? "Completed" : "Active")}\n";
        }
        //missionText.text = $"Mission: {questName}\nObjective: {questDescription}";
    }
}