using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCScript : MonoBehaviour
{
    public Sentences[] sentences;
    public QuestManager questManager;
    [SerializeField] private Quest[] quest;
    private bool playerIsClose;
    [SerializeField] private SpriteRenderer questMarkerSprite;
    [SerializeField] private SpriteRenderer speakIcon;
    public bool hasTalked = false;
    

    public void UpdateQuestMarker()
    {
        if (quest != null && quest.Length > 0)
        {
            if (!questManager.IsQuestActive(quest[0].questName) &&
            !questManager.CompletedQuests.Exists(q => q.questName == quest[0].questName))
            {
                questMarkerSprite.enabled = true;
            }
            else
            {
                questMarkerSprite.enabled = false;
            }
        }
        else
        {
            questMarkerSprite.enabled = false;
        }
    }
    void Update()
    {
        UpdateQuestMarker();
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        if (playerIsClose)
        {
            speakIcon.enabled = true;
        }
        else
        {
            speakIcon.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.B) && playerIsClose)
        {
            speakIcon.enabled = true;
            // questManager.CompleteQuest(quest[0].questName);
        }

        if (Input.GetKeyDown(KeyCode.C) && playerIsClose)
        {
            speakIcon.enabled = false;
            // if (playerMovement.scoreTester >= quest[0].pointsRequirement)
            // {
            //     questManager.AddQuest(quest[0]);
            // }
        }


        if (Input.GetKeyDown(KeyCode.E) && playerIsClose && !DialogueManager.Instance.dialoguePanel.activeSelf)
        {
            DialogueManager.Instance.StartDialogue(sentences, quest.Length > 0 ? quest[0] : null);
            if (!hasTalked && QuestManager.Instance.IsQuestActive("Ontmoeting"))
            {
                hasTalked = true;
                QuestManager.Instance.taskSetter("NPC1");
                DialogueManager.Instance.DisplayQuests();
                Debug.Log("fired");
            }
        }


        if (Input.GetKeyDown(KeyCode.G) && DialogueManager.Instance.isDialogueActive)
        {
            DialogueManager.Instance.EndDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Checks if player is in range and sets bool to true if in range
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }



    private void OnTriggerExit2D(Collider2D other)
    {
        // Checks if player is in range and sets bool to false if out of range
        // also ends the dialogue if the player is out of range
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            DialogueManager.Instance.EndDialogue();
        }
    }
}
