using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TheoryManager : MonoBehaviour
{
    [TextArea]
    public string[] TheoryStrings;
    public Button[] buttons;
    public TextMeshProUGUI TheoryText;
    public Button ExitButton;
    public Button BackButton;
    


    void Start()
    {
        BackButtonFunction();
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => OnButtonClicked(index));
        }
        ExitButton.onClick.AddListener(() => BtnsVisEnabler());
        BackButton.onClick.AddListener(() => BackButtonFunction());
    }

    void OnButtonClicked(int index)
    {
        switch (index)
        {
            case 0:
                BtnVisDisabler();
                BackButton.gameObject.SetActive(true);
                TheoryText.text = TheoryStrings[0];
                break;
            case 1:
                BtnVisDisabler();
                BackButton.gameObject.SetActive(true);
                TheoryText.text = TheoryStrings[1];
                break;
            case 2:
                BtnVisDisabler();
                BackButton.gameObject.SetActive(true);
                TheoryText.text = TheoryStrings[2];
                break;
            case 3:
                BtnVisDisabler();
                BackButton.gameObject.SetActive(true);
                TheoryText.text = TheoryStrings[3];
                break;
            case 4:
                BtnVisDisabler();
                BackButton.gameObject.SetActive(true);
                TheoryText.text = TheoryStrings[4];
                break;
            case 5:
                BtnVisDisabler();
                BackButton.gameObject.SetActive(true);
                TheoryText.text = TheoryStrings[5];
                break;
            default:
                BtnVisDisabler();
                BackButton.gameObject.SetActive(true);
                TheoryText.text = "error, no TheoryStrings";
                Debug.Log("error");
                break;
        }
    }
    public void BackButtonFunction()
    {
        BackButton.gameObject.SetActive(false);
        TheoryText.text = "";
        foreach (Button btn in buttons)
        {
            btn.gameObject.SetActive(true);
        }
    }

    public void BtnsVisEnabler()
    {
        DialogueManager.instance.DisplayTheory();
        DialogueManager.instance.isDialogueActive = false;
    }

    public void BtnVisDisabler()
    {
        foreach (Button btn in buttons)
        {
            btn.gameObject.SetActive(false);
        }
    }
}
