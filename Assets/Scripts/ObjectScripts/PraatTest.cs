using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PraatTest : MonoBehaviour
{
    public GameObject FirstButton;
    public GameObject SecondButton;
    string[,] story = new string[,]
    {
        {"hoi","ja","nee"},
        {"hoi2","ja2","nee2"},
        {"hoi3","ja3","nee3"}
    };

    int currentStep = 0;

    void Start()
    {
        ShowStory();
    }

    public void ShowStory()
    {
        if (currentStep < story.GetLength(0))
        {
            Debug.Log(story[currentStep, 0]);
        }
        else
        {
            Debug.Log("End");
        }
    }


    public void ChooseOption(int choice)
    {
        if (choice == 1 || choice == 2)
        {
            // displays the 
            Debug.Log(story[currentStep, choice]);
            currentStep++;
            ShowStory();
        }
        else
        {
            Debug.Log("invalid choice");
        }
    }
}
