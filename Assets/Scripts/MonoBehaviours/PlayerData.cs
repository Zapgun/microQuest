using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    public static CharacterData data = new CharacterData ();
    public static string currentRoom;

    void Start() {
        if (Application.isEditor) LoadData(); // Load a character if we are in edit mode
    }

    /// <summary>
    ///  Save player data to JSON file
    /// </summary>
    public static void SaveData () {
        string filePath = Application.persistentDataPath + "/gamesave.txt";
        Debug.Log ("Saved player data: " + data.name);

        // Save your saveData object to a json file.
        string json = JsonUtility.ToJson (data, true); // 'true' makes it look pretty
        File.WriteAllText (filePath, json);

        Debug.Log ("Game Saved to: " + filePath);
    }

    public static void LoadData () {
        string filePath = Application.persistentDataPath + "/gamesave.txt";
        if (File.Exists (filePath)) {
            // read the object data from file
            string retrievedData = File.ReadAllText (filePath);
            data = JsonUtility.FromJson<CharacterData> (retrievedData);
            Debug.Log ("Game Data Loaded from: " + filePath);
            Debug.Log ("Loaded character is: " + data.name);
        } else {
            Debug.Log ("No save file named '" + filePath + "' found");
        }
    }

}