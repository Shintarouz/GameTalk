// For information on how the system works : https://www.youtube.com/watch?v=-7I0slJyi8g&list=LL&index=1&t=186s
// TLDR : Set up your scene index numbers through File -> Build Settings -> Scenes In Build.
// Then make a new LevelSwitcher object and attach this script to it, then set Scene Build Index to the index of the scene in the inspector menu.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSceneLoader : MonoBehaviour
{
    public int sceneBuildIndex;

    private void OnTriggerEnter2D(Collider2D other) {
        print("Trigger Entered");


        if(other.tag == "Player") {
            print("Switching Scene to");
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}
