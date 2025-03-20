using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    public GameObject contButton;
    

    private Queue<string> sentences;
    public bool isDialogueActive = false;

    void Awake()
    {
        if ( instance == null )
        {
            instance = this;
        }
        sentences = new Queue<string>();
        dialoguePanel.SetActive(false);
    }

    public void StartDialogue(string npcName, string[] dialogue)
    {
        if (isDialogueActive) return;

        isDialogueActive = true;
        dialoguePanel.SetActive(true);
        nameText.text = npcName;
        sentences.Clear();

        foreach(string sentence in dialogue)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
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
    }
}
