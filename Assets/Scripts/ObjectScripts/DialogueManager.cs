using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    private Quest currentQuest;

    [Header("Dialogue References")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    private Sentences[] dialogueSentences;
    public bool isDialogueActive = false;
    private int index;
    public Image npcImage;
    public Sprite[] npcIcons;


    [Header("Quest References")]
    public TextMeshProUGUI missionText;
    public QuestManager questManager;


    [Header("Theory References")]
    public GameObject theoryCanvas;


    [Header("Buttons")]
    public GameObject contButton1;
    public GameObject contButton2;
    public GameObject contButton3;
    public GameObject contButton4;
    public GameObject nextPageButton;
    private TextMeshProUGUI contButton1Text;
    private TextMeshProUGUI contButton2Text;


    public void DisplayTheory()
    {
        if (!isDialogueActive)
        {
            isDialogueActive = true;
            theoryCanvas.SetActive(!theoryCanvas.activeSelf);
        }
        else
        {
            isDialogueActive = false;
            theoryCanvas.SetActive(!theoryCanvas.activeSelf);
        }
    }

    void Awake()
    {
        if ( Instance == null )
        {
            Instance = this;
        }
        dialoguePanel.SetActive(false);
        questManager = FindObjectOfType<QuestManager>();
        contButton1Text = contButton1.GetComponentInChildren<TextMeshProUGUI>();
        contButton2Text = contButton2.GetComponentInChildren<TextMeshProUGUI>();

        contButton1.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnAnswerClicked(contButton1Text.text));
        contButton2.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnAnswerClicked(contButton2Text.text));
        contButton3.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => DisplayNextSentence());
        contButton4.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => ContinueButton());
        nextPageButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => NextPage());
    }

    public void ContinueButton()
    {
        index++;
        DisplayNextSentence();
        contButton3.SetActive(false);
        UpdateNextButtonText();
    }
    public void StartDialogue(Sentences[] arraySentences, Quest quest)
    {
        index = 0;
        if (isDialogueActive) return;

        currentQuest = quest;
        dialogueSentences = arraySentences;
        isDialogueActive = true;
        dialoguePanel.SetActive(true);
        contButton3.SetActive(false);
        int npcID = dialogueSentences[index].npcID;
        npcIDChecker(npcID);
        DisplayNextSentence();
        UpdateNextButtonText();
    }

    public void DisplayNextSentence()
    {
        dialogueText.pageToDisplay = 1;
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        if(index >= dialogueSentences.Length)
        {
            if (currentQuest != null) {questManager.AddQuest(currentQuest);}
            questManager.DisplayPoints();
            EndDialogue();
            return;
        }
        int npcID = dialogueSentences[index].npcID;
        npcIDChecker(npcID);
        string sentence = dialogueSentences[index].sentence;
        string rightanswer = dialogueSentences[index].rightAnswer;
        string wronganswer = dialogueSentences[index].wrongAnswer;

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

        dialogueText.text = sentence;
        dialogueText.ForceMeshUpdate();

        contButton1.SetActive(true);
        contButton2.SetActive(true);
        contButton3.SetActive(false);
        UpdateNextButtonText();
    }


    public void EndDialogue()
    {
        isDialogueActive = false;
        dialoguePanel.SetActive(false);
        contButton1.SetActive(false);
        contButton2.SetActive(false);
        theoryCanvas.SetActive(false);
    }

    public void DisplayQuests()
    {
        if (questManager.ActiveQuests.Count == 0) // if no active quests display "No Active Quests"
        {
            missionText.text = "Geen actieve missies momenteel";
            return;
        }
        
        missionText.text = "";

        for(int i = 0; i < questManager.ActiveQuests.Count; i++)
        {
            if (i > 0)
            {
                missionText.text += "\n";
            }
            Quest q = questManager.ActiveQuests[i];
            int taskCount = q.tasksToComplete != null ? q.tasksToComplete.Count : 0;
            missionText.text += $"Quest: {q.questName}\nDoel: {q.description}\nTasks to complete: {taskCount}\n";
            missionText.ForceMeshUpdate();
            // missionText.text += $"Quest: {q.questName}\nDoel: {q.description}\n"; // \nStatus: {(q.isCompleted ? "Completed" : "Active")}
        }
    }

    public void DisplayResponse(string response)
    {
        dialogueText.text = string.IsNullOrEmpty(response)
            ? "{missing response}"
            : response;
        dialogueText.pageToDisplay = 1;
        dialogueText.ForceMeshUpdate();
        UpdateNextButtonText();
    }
    
    public void OnAnswerClicked(string buttonText)
    {
        string rightAnswerResponse = dialogueSentences[index].rightAnswerResponse;
        string wrongAnswerResponse = dialogueSentences[index].wrongAnswerResponse;
        string CA = dialogueSentences[index].rightAnswer;

        if(buttonText == CA)
        {
            index = index + 1;
            contButton1.SetActive(false);
            contButton2.SetActive(false);
            contButton3.SetActive(true);
            DisplayResponse(rightAnswerResponse);
            UpdateNextButtonText();
        }
        else
        {
            if (index > 0)
            {
                index = index - 1;
            }
            else if (index == 0)
            {
                EndDialogue();
            }
            DisplayResponse(wrongAnswerResponse);
            contButton1.SetActive(false);
            contButton2.SetActive(false);
            contButton3.SetActive(true);
            UpdateNextButtonText();

        }
    }

    public void NextPage()
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
        UpdateNextButtonText();
    }

    public void npcIDChecker(int npcID)
    {
        switch (npcID)
        {
            case 1:
                nameText.text = "Verteller";
                npcImage.sprite = npcIcons[0];
                break;
            case 2:
                nameText.text = "Politie agent";
                npcImage.sprite = npcIcons[1];
                break;
            case 3:
                nameText.text = "Head";
                npcImage.sprite = npcIcons[2];
                break;
            case 4:
                nameText.text = "BeachBoy";
                npcImage.sprite = npcIcons[3];
                break;
            case 5:
                nameText.text = "Politie agent 2";
                npcImage.sprite = npcIcons[4];
                break;
            case 6:
                nameText.text = "Sarah";
                npcImage.sprite = npcIcons[5];
                break;
            default:
                nameText.text = "Error";
                npcImage.sprite = npcIcons[3];
                break;
        }
    }
    public void UpdateNextButtonText()
    {
        nextPageButton.GetComponentInChildren<TextMeshProUGUI>().text = $"Page {dialogueText.pageToDisplay}/{dialogueText.textInfo.pageCount}";
        dialogueText.ForceMeshUpdate();
    }
}