using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum CubeColor {red, green, blue};

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    // Global Variables

    // Awake 
    void Awake() {
        //Application.targetFrameRate = Screen.currentResolution.refreshRate;

        // Singleton pattern here!
        if (instance == null) {
            instance = this;
        } else if (instance != null) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this); // This game object will pass from scene to scene
        Init();
    }

    void Init() {
        // Add additional things to happen 

        // Then finally load the first scene
        if (SceneManager.GetActiveScene().name == "00 Start")
            SceneManager.LoadScene("01 Menu");
        else
            Debug.Log("Skipping 00 Start Loading");
    }
}
