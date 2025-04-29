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

    // public void QuestGiver()
    // {
    //     if (quest.Length > 0 && questManager != null)
    //     {
    //         Quest currentquest
    //     }
    // }
    public void UpdateQuestMarker()
    {
        if (quest.Length > 0)
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
        if (Input.GetKeyDown(KeyCode.B) && playerIsClose)
        {
            questManager.CompleteQuest(quest[0].questName);
        }

        if (Input.GetKeyDown(KeyCode.C) && playerIsClose)
        {
            if (playerMovement.scoreTester >= quest[0].pointsRequirement)
            {
                questManager.AddQuest(quest[0]);
            }
        }


        if (Input.GetKeyDown(KeyCode.E) && playerIsClose && !DialogueManager.Instance.dialoguePanel.activeSelf)
        {
            DialogueManager.Instance.StartDialogue(sentences);
        }


        if (Input.GetKeyDown(KeyCode.G) && DialogueManager.Instance.isDialogueActive)
        {
            DialogueManager.Instance.EndDialogue();
        }
    }
    
    public void QuestGiver()
    {
        if (quest != null)
        {
            questManager.AddQuest(quest[0]);
        }
        else
        {
            return;
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
