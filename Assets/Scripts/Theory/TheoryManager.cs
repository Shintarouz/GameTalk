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
                taskSetter("read book1");
                BtnVisDisabler();
                checkButton.gameObject.SetActive(true);
                theoryText.text = theoryStrings[0];
                theoryText.gameObject.SetActive(true);
                break;
            case 1:
                taskSetter("read book2");
                BtnVisDisabler();
                checkButton.gameObject.SetActive(true);
                theoryText.text = theoryStrings[1];
                theoryText.gameObject.SetActive(true);
                break;
            case 2:
                taskSetter("read book3");
                BtnVisDisabler();
                checkButton.gameObject.SetActive(true);
                theoryText.text = theoryStrings[2];
                theoryText.gameObject.SetActive(true);
                break;
            case 3:
                taskSetter("read book4");
                BtnVisDisabler();
                checkButton.gameObject.SetActive(true);
                theoryText.text = theoryStrings[3];
                theoryText.gameObject.SetActive(true);
                break;
            case 4:
                taskSetter("read book5");
                BtnVisDisabler();
                checkButton.gameObject.SetActive(true);
                theoryText.text = theoryStrings[4];
                theoryText.gameObject.SetActive(true);
                break;
            case 5:
                taskSetter("read book6");
                BtnVisDisabler();
                checkButton.gameObject.SetActive(true);
                theoryText.text = theoryStrings[5];
                theoryText.gameObject.SetActive(true);
                break;
            default:
                BtnVisDisabler();
                checkButton.gameObject.SetActive(true);
                theoryText.text = "error, no TheoryStrings";
                Debug.Log("error");
                break;
        }
    }

    public void taskSetter(string test)
    {
        foreach ( var quest in QuestManager.Instance.ActiveQuests)
            {
                quest.completeTask(test);
            }
    }
    public void BackButtonFunction()
    {
        checkButton.gameObject.SetActive(false);
        theoryText.gameObject.SetActive(false);
        foreach (Button btn in buttons)
        {
            btn.gameObject.SetActive(true);
        }
    }

    public void BtnsVisEnabler()
    {
        DialogueManager.Instance.DisplayTheory();
    }

    public void BtnVisDisabler()
    {
        foreach (Button btn in buttons)
        {
            btn.gameObject.SetActive(false);
        }
    }
}
