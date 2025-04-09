using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TheoryManager : MonoBehaviour
{
    public Button[] buttons;
    public Image Background;
    public TextMeshProUGUI TheoryText;
    public Button ExitButton;
    public Button RertryButton;


    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => OnButtonClicked(index));
        }
        ExitButton.onClick.AddListener(() => BtnVisDisabler());
        RertryButton.onClick.AddListener(() => BtnsVisEnabler());
    }

    void OnButtonClicked(int index)
    {
        switch (index)
        {
            case 0:
                TheoryText.text = "Case 1 : The fitness grammpacer test is a....";
                break;
            case 1:
                TheoryText.text = "Case 2 : The fitness grammpacer test is a....";
                break;
            case 2:
                TheoryText.text = "Case 3 : The fitness grammpacer test is a....";
                break;
            case 3:
                TheoryText.text = "Case 4 : The fitness grammpacer test is a....";
                break;
            case 4:
                TheoryText.text = "Case 5 : The fitness grammpacer test is a....";
                break;
            case 5:
                TheoryText.text = "Case 6 : The fitness grammpacer test is a....";
                break;
            default:
                Debug.Log("error");
                break;
        }
    }

    public void BtnsVisEnabler()
    {
        foreach (Button btn in buttons)
        {
            btn.gameObject.SetActive(true);
        }
    }

    public void BtnVisDisabler()
    {
        foreach (Button btn in buttons)
        {
            btn.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
