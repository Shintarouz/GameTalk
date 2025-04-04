using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;


public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI missionText;
    public bool isDialogueActive = false;


    private QuestManager questManager;
    private Quest currentQuest;


    private Sentences[] DialogueSentences;
    private int index;

    public GameObject contButton1;
    public GameObject contButton2;
    public GameObject contButton3;
    public GameObject NextButton;
    private TextMeshProUGUI contButton1Text;
    private TextMeshProUGUI contButton2Text;
    private TextMeshProUGUI contButton3Text;

    private bool isTyping = false;

    void Awake()
    {
        if ( instance == null )
        {
            instance = this;
        }
        dialoguePanel.SetActive(false);
        questManager = FindObjectOfType<QuestManager>();
        contButton1Text = contButton1.GetComponentInChildren<TextMeshProUGUI>();
        contButton2Text = contButton2.GetComponentInChildren<TextMeshProUGUI>();
        contButton3Text = contButton3.GetComponentInChildren<TextMeshProUGUI>();

        contButton1.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnAnswerClicked(contButton1Text.text));
        contButton2.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnAnswerClicked(contButton2Text.text));
        contButton3.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => DisplayNextSentence());
        NextButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => NextPage());
    }


    public void StartDialogue(Quest quest, Sentences[] arraySentences)
    {
        dialogueText.pageToDisplay = 1;
        index = 0;
        if (isDialogueActive) return;

        DialogueSentences = arraySentences;
        currentQuest = quest;
        isDialogueActive = true;
        dialoguePanel.SetActive(true);
        contButton3.SetActive(false);
        int npcID = DialogueSentences[index].npcID;
        npcIDChecker(npcID);
        DisplayNextSentence();
        UpdateNextButtonText();
    }

    public void DisplayNextSentence()
    {
        dialogueText.pageToDisplay = 1;
        // PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        if(index >= DialogueSentences.Length)
        {
            // playerMovement.scoreTester += 5;
            EndDialogue();
            return;
        }
        int npcID = DialogueSentences[index].npcID;
        npcIDChecker(npcID);
        string sentence = DialogueSentences[index].sentence;
        string rightanswer = DialogueSentences[index].rightAnswer;
        string wronganswer = DialogueSentences[index].wrongAnswer;

        int randomChoice = Random.Range(0, 2);
        if (randomChoice == 0)
        {
            contButton1Text.text = rightanswer;
            contButton2Text.text = wronganswer;
        }
        else
        {
            contButton1Text.text = wronganswer;
            contButton2Text.text = rightanswer;
        }
        StopAllCoroutines();
        dialogueText.text = "";
        StartCoroutine(Typing(sentence));
        
        contButton1.SetActive(true);
        contButton2.SetActive(true);
        contButton3.SetActive(false);
        UpdateNextButtonText();
    }



    IEnumerator Typing(string sentence)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.001f);
        }
        isTyping = false;
    }

    public void EndDialogue()
    {
        
        isDialogueActive = false;
        dialoguePanel.SetActive(false);
        contButton1.SetActive(false);
        contButton2.SetActive(false);

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

        for(int i = 0; i < questManager.activeQuests.Count; i++)
        {
            if (i > 0)
            {
                missionText.text += "\n";
            }
            Quest q = questManager.activeQuests[i];
            missionText.text += $"Quest: {q.questName}\nDoel: {q.description}\n"; // \nStatus: {(q.isCompleted ? "Completed" : "Active")}
        }

        // foreach (Quest q in questManager.activeQuests)
        // {
        //     missionText.text += $"Quest: {q.questName}\nObjective: {q.description}\nStatus: {(q.isCompleted ? "Completed" : "Active")}\n";
        // }
    }

    public void DisplayResponse(string response)
    {
        StopAllCoroutines();
        dialogueText.text = "";
        if (response != "")
        {
            StartCoroutine(Typing(response));
        }
        else
        {
            StartCoroutine(Typing("{Missing a response, please add a response}"));
        }
        dialogueText.pageToDisplay = 1;
        UpdateNextButtonText();
    }
    
    public void OnAnswerClicked(string buttonText)
    {
        string rightAnswerResponse = DialogueSentences[index].rightAnswerResponse;
        string wrongAnswerResponse = DialogueSentences[index].wrongAnswerResponse;
        string CA = DialogueSentences[index].rightAnswer;

        if(buttonText == CA)
        {
            index = index + 1;
            contButton1.SetActive(false);
            contButton2.SetActive(false);
            contButton3.SetActive(true);
            DisplayResponse(rightAnswerResponse);
        }
        else
        {
            if (index > 0)
            {
                index = index - 1;
            }
            DisplayResponse(wrongAnswerResponse);
            contButton1.SetActive(false);
            contButton2.SetActive(false);
            contButton3.SetActive(true);

        }
    }

    public void NextPage()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueText.text = DialogueSentences[index].sentence;
            isTyping = false;
            dialogueText.ForceMeshUpdate();
        }
        else
        {
            if (dialogueText.pageToDisplay == 0)
            {
                dialogueText.pageToDisplay = 1;
            }
            else if (dialogueText.pageToDisplay < dialogueText.textInfo.pageCount)
            {
                dialogueText.pageToDisplay++;
            }
            else
            {
                dialogueText.pageToDisplay = 1;
            }
        }
        UpdateNextButtonText();
    }

    public void npcIDChecker(int npcID)
    {
        switch (npcID)
        {
            case 1:
                nameText.text = "John";
                break;
            case 2:
                nameText.text = "Marcus";
                break;
            case 3:
                nameText.text = "Stewart";
                break;
            case 99:
                nameText.text = "Verteller";
                break;
            default:
                nameText.text = "Error";
                break;
        }
    }
    void Update()
    {
        UpdateNextButtonText();
    }
    public void UpdateNextButtonText()
    {
        NextButton.GetComponentInChildren<TextMeshProUGUI>().text = $"Page {dialogueText.pageToDisplay}/{dialogueText.textInfo.pageCount}";
    }
}