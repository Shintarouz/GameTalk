using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TheoryManager : MonoBehaviour
{
    [TextArea]
    public string[] theoryStrings;
    public Button[] buttons;
    public TextMeshProUGUI theoryText;
    public Button exitButton;
    public Button checkButton;
    


    void Start()
    {
        BackButtonFunction();
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => OnButtonClicked(index));
        }
        exitButton.onClick.AddListener(() => BtnsVisEnabler());
        checkButton.onClick.AddListener(() => BackButtonFunction());
    }

    void OnButtonClicked(int index)
    {
        switch (index)
        {
            case 0:
                BtnVisDisabler();
                checkButton.gameObject.SetActive(true);
                theoryText.text = theoryStrings[0];
                theoryText.gameObject.SetActive(true);
                QuestManager.Instance.taskSetter("read book1");
                break;
            case 1:
                BtnVisDisabler();
                checkButton.gameObject.SetActive(true);
                theoryText.text = theoryStrings[1];
                theoryText.gameObject.SetActive(true);
                QuestManager.Instance.taskSetter("read book2");
                break;
            case 2:
                BtnVisDisabler();
                checkButton.gameObject.SetActive(true);
                theoryText.text = theoryStrings[2];
                theoryText.gameObject.SetActive(true);
                QuestManager.Instance.taskSetter("read book3");
                break;
            case 3:
                BtnVisDisabler();
                checkButton.gameObject.SetActive(true);
                theoryText.text = theoryStrings[3];
                theoryText.gameObject.SetActive(true);
                QuestManager.Instance.taskSetter("read book4");
                break;
            case 4:
                BtnVisDisabler();
                checkButton.gameObject.SetActive(true);
                theoryText.text = theoryStrings[4];
                theoryText.gameObject.SetActive(true);
                QuestManager.Instance.taskSetter("read book5");
                break;
            case 5:
                BtnVisDisabler();
                checkButton.gameObject.SetActive(true);
                theoryText.text = theoryStrings[5];
                theoryText.gameObject.SetActive(true);
                QuestManager.Instance.taskSetter("read book6");
                break;
            default:
                BtnVisDisabler();
                checkButton.gameObject.SetActive(true);
                theoryText.text = "error, no TheoryStrings";
                Debug.Log("error");
                break;
        }
    }

    // public void taskSetter(string objective)
    // {
    //     foreach ( var quest in QuestManager.Instance.ActiveQuests)
    //         {
    //             quest.completeTask(objective);
    //         }
    // }
    public void BackButtonFunction()
    {
        checkButton.gameObject.SetActive(false);
        theoryText.gameObject.SetActive(false);
        foreach (Button btn in buttons)
        {
            btn.gameObject.SetActive(true);
        }
        DialogueManager.Instance.DisplayQuests();
    }

    public void BtnsVisEnabler()
    {
        BackButtonFunction();
        DialogueManager.Instance.DisplayTheory();
        DialogueManager.Instance.DisplayQuests();
    }

    public void BtnVisDisabler()
    {
        foreach (Button btn in buttons)
        {
            btn.gameObject.SetActive(false);
        }
    }
}
