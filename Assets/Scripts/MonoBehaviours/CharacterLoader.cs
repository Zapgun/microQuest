using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Loads character data from default characters and allows saving to GameManager Player data
/// </summary>

public class CharacterLoader : MonoBehaviour
{
    public Characters defaultCharacters;
    public int charIndex = 0;

    CharacterData data = Player.data;

    public Text nameText;
    public Text placeholderText;
    public Text charClass;
    public Text attackText;
    public Text defenseText;
    public Text speedText;
    public Text healthText;
    public Image portrait;

    string portraitFile;
    string portraitName;

    // Start is called before the first frame update
    void Start()
    {
        if (defaultCharacters) {
            UpdateCharacterCard();
        } else {
            Debug.LogError("No DefaultCharacters linked!");
        }
    }

    /// <summary>
    /// Update character fields from default scriptable data
    /// </summary>
    void UpdateCharacterCard() {
        CharacterData character = defaultCharacters.characters[charIndex];
        placeholderText.text =character.name;
        charClass.text = character.charClass;
        portrait.sprite = Utility.LoadSprite(character.portraitFile, character.portraitName);
        portraitFile = character.portraitFile;
        portraitName = character.portraitName;       
        attackText.text = "" + defaultCharacters.characters[charIndex].attack;
        defenseText.text = "" + defaultCharacters.characters[charIndex].defense;
        speedText.text = "" + defaultCharacters.characters[charIndex].speed;
        healthText.text = "" + defaultCharacters.characters[charIndex].maxHealth;
        defaultCharacters.IsLoaded(charIndex);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            UpdateIndex();
        }
    }

    public void NextCharacter() {
        UpdateIndex();
    }

    public void PrevCharacter() {
        UpdateIndex(false);
    }

    void UpdateIndex(bool fwd = true) {
        if (fwd) {
            charIndex = charIndex + 1;
            if (charIndex == defaultCharacters.characters.Length) charIndex = 0;            
        } else {
            charIndex = charIndex - 1;
            if (charIndex < 0) charIndex = defaultCharacters.characters.Length - 1;            
        }
        UpdateCharacterCard();
    }


    public void SaveCharacter() {
        // Save the player namespace MyNamespace
        // ...

        GetPlayerData();
        Player.SaveData();
        // Load the next scene
        SceneManager.LoadScene(2); // 02 Room A
    }

    /// <summary>
    /// Loads data into default Player on GameManager
    /// </summary>
    void GetPlayerData() {
        if (string.IsNullOrEmpty (nameText.text))
            data.name = placeholderText.text;
        else
            data.name = nameText.text;

        data.charClass = charClass.text;
        data.portraitFile = portraitFile;
        data.portraitName = portraitName;
        data.attack = int.Parse(attackText.text);
        data.defense = int.Parse(defenseText.text);
        data.speed = int.Parse(speedText.text);
        data.health = int.Parse(healthText.text);                                
    }
}
