using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomBanner : MonoBehaviour
{
    public Text nameText;
    
    public void DisableBanner() {
        gameObject.SetActive(false);
    }
}
