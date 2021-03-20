using UnityEngine;

[System.Serializable]
public class CharacterData
{
    public string name;
    public string charClass;

    public string portraitFile;
    public string portraitName;

    // Attack / Defense values
    public int attack;
    public int defense;
    public int speed;

    // Hit Points
    public int health;
    public int maxHealth = 100;
}

[CreateAssetMenu(menuName = "Scriptable Objects/Characters")]
public class Characters : ScriptableObject
{
    public CharacterData[] characters;

    public void IsLoaded(int idx) {
        Debug.Log(characters[idx].name + " data is loaded.");
    }

    public void RollUpChar(int idx) {
        characters[idx].attack = Random.Range(3,18);
        characters[idx].defense = Random.Range(3,18);
        characters[idx].speed = Random.Range(3,18);
        characters[idx].health = characters[idx].maxHealth;
    }
}
