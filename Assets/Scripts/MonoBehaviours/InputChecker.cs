using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This class checks to which input device is being used
/// and disabled the mouse cursor if a controller is in use.
/// </summary>
public class InputChecker : MonoBehaviour {
    private static InputChecker _instance;

    public static InputChecker Instance { get { return _instance; } }

    Vector3 tmpMousePosition;

    private void Awake () {
        if (_instance != null && _instance != this) {
            Destroy (this.gameObject);
        } else {
            _instance = this;
        }

        tmpMousePosition = Input.mousePosition;
    }

    public enum InputType {
        MouseKeyboard,
        Controller
        };

        private InputType InputState = InputType.MouseKeyboard;

        void Update () {
        switch (InputState) {
        case InputType.MouseKeyboard:
            if (isControllerInput ()) {
                InputState = InputType.Controller;
                Debug.Log ("Switched Input to Controller");
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            break;
        case InputType.Controller:
            if (isMouseKeyboard ()) {
                InputState = InputType.MouseKeyboard;
                Debug.Log ("Switched Input to Mouse/Keyboard");
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            break;
        }
    }

    public InputType GetInputType () {
        return InputState;
    }

    public bool UsingController () {
        return InputState == InputType.Controller;
    }

    private bool isMouseKeyboard () {
        if (tmpMousePosition != Input.mousePosition || 
            Input.anyKey ||
            Input.GetMouseButton (0) ||
            Input.GetMouseButton (1) ||
            Input.GetMouseButton (2) ||
            Input.GetAxis ("Mouse ScrollWheel") != 0.0f) {
            tmpMousePosition = Input.mousePosition;
            return true;
        }
        return false;
    }

    private bool isControllerInput () {
        // joystick buttons
        // check if we're not using a key for the axis' at the end 
        if (Input.GetKey (KeyCode.Joystick1Button0) ||
            Input.GetKey (KeyCode.Joystick1Button1) ||
            Input.GetKey (KeyCode.Joystick1Button2) ||
            Input.GetKey (KeyCode.Joystick1Button3) ||
            Input.GetKey (KeyCode.Joystick1Button4) ||
            Input.GetKey (KeyCode.Joystick1Button5) ||
            Input.GetKey (KeyCode.Joystick1Button6) ||
            Input.GetKey (KeyCode.Joystick1Button7) ||
            Input.GetKey (KeyCode.Joystick1Button8) ||
            Input.GetKey (KeyCode.Joystick1Button9) ||
            Input.GetKey (KeyCode.Joystick1Button10) ||
            Input.GetKey (KeyCode.Joystick1Button11) ||
            Input.GetKey (KeyCode.Joystick1Button12) ||
            Input.GetKey (KeyCode.Joystick1Button13) ||
            Input.GetKey (KeyCode.Joystick1Button14) ||
            Input.GetKey (KeyCode.Joystick1Button15) ||
            Input.GetKey (KeyCode.Joystick1Button16) ||
            Input.GetKey (KeyCode.Joystick1Button17) ||
            Input.GetKey (KeyCode.Joystick1Button18) ||
            Input.GetKey (KeyCode.Joystick1Button19) ||
            (Input.GetAxisRaw ("Horizontal") != 0.0f && !Input.anyKey) ||
            (Input.GetAxisRaw ("Vertical") != 0.0f && !Input.anyKey)) {
            return true;
        }

        return false;
    }
}