using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class BookshelfScriptZone : MonoBehaviour
{
    private bool isInRange;
    private KeyCode interactKey = KeyCode.J;
    public UnityEvent interactAction;


    void Update()
    {
        if(isInRange)
        {
            if(Input.GetKeyDown(interactKey)) // if interactKey pressed run TheorySwitcher()
            {
                DialogueManager.Instance.DisplayTheory();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
    }
}
