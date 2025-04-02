using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sentence", menuName = "Dialogue/Sentence")]
public class Sentences : ScriptableObject
{
    public int npcID;
    public string sentence;
    public string rightAnswer;
    public string wrongAnswer;
    public bool hasAnswers;
}
