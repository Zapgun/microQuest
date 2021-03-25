using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadPortrait : MonoBehaviour
{

    public Image portrait;
    
    // Start is called before the first frame update
    void Start()
    {
        portrait = GetComponent<Image>();
        CharacterData data = PlayerData.data;
        portrait.sprite = Utility.LoadSprite(data.portraitFile, data.portraitName);;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
