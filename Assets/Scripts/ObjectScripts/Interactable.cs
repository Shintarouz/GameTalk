// Tutorial used : https://www.youtube.com/watch?v=cLzG1HDcM4s&t=317s //
// After adapted to add more //


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    public SpriteRenderer Lock;
    public Sprite[] LockIcons;
    private BoxCollider2D wall;
    public int RequiredScenePoints;
    private bool isInRange;
    private KeyCode interactKey = KeyCode.E;
    public UnityEvent interactAction;
    public int sceneBuildIndex;
    
    void Start()
    {
        wall = Lock.GetComponent<BoxCollider2D>();
    }
    public void sceneSwitch()
    {
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }

    public void numberAdded()
    {
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        if (QuestManager.Instance.IsQuestCompleted("Theorie Expert") && QuestManager.Instance.IsQuestCompleted("Ontmoeting"))
        {
            sceneSwitch();
        }
        // else
        // {
        //     playerMovement.scoreTester += 3;
        //     QuestManager.Instance.DisplayPoints();
        //     Debug.Log("Not Enough Points, Here have 3 points!");
        // }
    }
    void Update()
    {
        // PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        // if (playerMovement.scoreTester <= RequiredScenePoints)
        if (QuestManager.Instance.IsQuestCompleted("Theorie Expert") && QuestManager.Instance.IsQuestCompleted("Ontmoeting"))
        {
            Lock.sprite = LockIcons[0];
            wall.enabled = false;

        }
        else
        {
            wall.enabled = true;
            Lock.sprite = LockIcons[1];
        }


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
