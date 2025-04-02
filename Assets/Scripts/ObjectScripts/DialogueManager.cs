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


    public void StartDialogue(string npcName, int npcID, Quest quest, Sentences[] arraySentences)
    {
        index = 0;
        if (isDialogueActive) return;

        DialogueSentences = arraySentences;

        currentQuest = quest;
        isDialogueActive = true;
        dialoguePanel.SetActive(true);
        contButton3.SetActive(false);
        nameText.text = npcName;
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        // PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        if(index >= DialogueSentences.Length)
        {
            // playerMovement.scoreTester += 5;
            EndDialogue();
            return;
        }
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

        foreach (Quest q in questManager.activeQuests)
        {
            missionText.text += $"\nQuest: {q.questName}\nObjective: {q.description}\nStatus: {(q.isCompleted ? "Completed" : "Active")}\n";
        }
        
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
            // DisplayNextSentence();
        }
        else
        {
            if (index > 0)
            {
                index = index - 1;
                // DisplayNextSentence();
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
            NextButton.GetComponentInChildren<TextMeshProUGUI>().text = $"Page {dialogueText.pageToDisplay}/{dialogueText.textInfo.pageCount}";
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
        NextButton.GetComponentInChildren<TextMeshProUGUI>().text = $"Page {dialogueText.pageToDisplay}/{dialogueText.textInfo.pageCount}";
        // if (dialogueText.pageToDisplay == 0)
        // {
        //     dialogueText.pageToDisplay = 1;
        // }
        // if (dialogueText.pageToDisplay < dialogueText.textInfo.pageCount)
        // {
        //     dialogueText.pageToDisplay++;
        // }
        // else if (dialogueText.pageToDisplay == dialogueText.textInfo.pageCount)
        // {
        //     dialogueText.pageToDisplay = 1;
        // }
        // NextButton.GetComponentInChildren<TextMeshProUGUI>().text = $"Page {dialogueText.pageToDisplay}/{dialogueText.textInfo.pageCount}";
    }

    public string[] Chunker(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return new string[0];
        }

        List<string> chunks = new List<string>();
        for (int i = 0; i < input.Length; i += 400)
        {
            int length = Mathf.Min(400, input.Length - i );
            chunks.Add(input.Substring(i, length));
        }

        return chunks.ToArray();
    }
}