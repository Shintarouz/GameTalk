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

    public void OpenTheoryMenuCaller()
    {
        DialogueManager.instance.TheorySwitcher();
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange)
        {
            if(Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
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
    void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
    }
}
