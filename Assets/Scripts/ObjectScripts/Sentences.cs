using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(fileName = "New Sentence", menuName = "Dialogue/Sentence")]
[Serializable]
public class Sentences
{
    public string rightAnswerResponse;
    public string wrongAnswerResponse;
    public int npcID;
    public string sentence;
    public string rightAnswer;
    public string wrongAnswer;
    public bool hasAnswers;
}
