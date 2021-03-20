using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{

    public GameObject namePanel;

    void Start() {
         namePanel = GameObject.FindGameObjectWithTag("NamePanel");
         namePanel.SetActive(false);
    }

    public void NewGame() {
        // Load next scene, initialize data
        namePanel.SetActive(true);
    }

    public void LoadGame() {
        // Load next scene, load data
        Player.LoadData();
        SceneManager.LoadScene(2); // 02 Room A
    }

    public void QuitGame() {
        // Quit application
        Debug.Log("Quit has been called");
        Application.Quit();
    }

    public void ShowNamePanel() {
        namePanel.SetActive(true);
    }

    public void CloseNamePanel() {
        namePanel.SetActive(false);
    }
}
