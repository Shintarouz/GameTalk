using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ScoreMeasure : MonoBehaviour
{
    public int scoreCounter = 0;
    public KeyCode interactKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(interactKey))
        {
            scoreCounter += 1;
            print(scoreCounter);
        }
    }
}
