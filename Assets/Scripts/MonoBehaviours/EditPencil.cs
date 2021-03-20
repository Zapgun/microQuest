using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditPencil : MonoBehaviour
{
    InputField inputField;
    public Image pencilImage;

    void Start() {
        inputField = GetComponent<InputField>();
    }

    // Disabled the pencil image if the input field has been edited
    public void OnValueChanged() {
        if (!pencilImage) return;
        if (string.IsNullOrEmpty (inputField.text)) {
            pencilImage.enabled = true;
        } else {
            pencilImage.enabled = false;
        }
    }
}
