using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomBanner : MonoBehaviour
{
    public TMP_Text nameText;
    
    public void DisableBanner() {
        gameObject.SetActive(false);
    }
}
