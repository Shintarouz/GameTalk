using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCScript : MonoBehaviour
{
    public string npcName;
    public string[] dialogue;
    private bool playerIsClose;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose && !DialogueManager.instance.dialoguePanel.activeSelf)
        {
            DialogueManager.instance.StartDialogue(npcName, dialogue);
        }

        if (Input.GetKeyDown(KeyCode.G) && DialogueManager.instance.isDialogueActive)
        {
            DialogueManager.instance.EndDialogue();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            DialogueManager.instance.EndDialogue();
        }
    }
}
