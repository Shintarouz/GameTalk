// Tutorial used : https://www.youtube.com/watch?v=cLzG1HDcM4s&t=317s //
// After adapted to add more //


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public int sceneBuildIndex;

    void Start()
    {
        //
    }

    public void sceneSwitch()
    {
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }

    public void numberAdded()
    {
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        if ( playerMovement.scoreTester >= 15)
        {
            sceneSwitch();
        }
        else
        {
            playerMovement.scoreTester += 3;
        }
    }
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
