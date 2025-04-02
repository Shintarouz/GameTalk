using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TheoryManager : MonoBehaviour
{
    [Header("Theory Canvas")]
    [SerializeField] private GameObject theoryCanvas;

    [Header("Buttons")]
    public GameObject theoryButtons;

    [Header("Player Detection")]
    [SerializeField] private Transform playerTransform;

    [Header("Dialogue Data")]
    [SerializeField] private List<TextAsset> TheoryList = new List<TextAsset>();

    private bool isInRange;
    public UnityEvent interactAction;



    private void Awake()
    {
        isInRange = false;
        theoryCanvas.SetActive(false);
    }


    public void Click(string buttonName)
    {
        int buttonIndex = GetButtonIndex(buttonName);
        
    }

    private void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.E))
        {
            theoryCanvas.SetActive(!theoryCanvas.activeSelf);
        }
    }

    private int GetButtonIndex(string buttonName)
    {
        if (buttonName.StartsWith("Theory") && buttonName.EndsWith("Button"))
        {
            string numberPart = buttonName.Replace("Theory", "").Replace("Button", "");
            if (int.TryParse(numberPart, out int index))
            {
                return index - 1;
            }
        }
        return -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("In range");
            isInRange = true;
        }
    }



    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("out of range");
        isInRange = false;
    }
}
