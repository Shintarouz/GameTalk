// // https://www.youtube.com/watch?v=aUi9aijvpgs

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class DataPersistenceManager : MonoBehaviour
// {
//     private GameData gameData;
//     public static DataPersistenceManager instance { get; private set; }

//     private void Awake()
//     {
//         if ( instance != null)
//         {
//             Debug.LogError("Found more then one Data Persistence Manager in the scene");

//         }
//         instance = this;
//     }

//     private void Start()
//     {
//         LoadGame();
//     }

//     public void NewGame()
//     {
//         this.gameData = new GameData();
//     }

//     public void LoadGame()
//     {
//         // TODO
//         if (this.gameData == null)
//         {
//             Debug.Log("No data was found")
//             NewGame();
//         }
//     }

//     public void SaveGame()
//     {

//     }

//     private void onApplicationQuit()
//     {
//         SaveGame();
//     }
// }
