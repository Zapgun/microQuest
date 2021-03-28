// Usage: In the inspector, punch in your desired settings and then 
// enter PLAY mode to apply.

using UnityEngine;
using UnityEngine.Assertions;

[ExecuteInEditMode]
public class PixelPerfectVCam : MonoBehaviour {
    
    Cinemachine.CinemachineVirtualCamera vCam;
    int oldScreenHeight;

    void Start () {
        vCam = GetComponent<Cinemachine.CinemachineVirtualCamera> ();
        Assert.IsNotNull (vCam);

        SetOrthographicSize ();
    }

    void Update() {
        if (Screen.height != oldScreenHeight)
        {
            SetOrthographicSize();
            oldScreenHeight = Screen.height;
        }
    }

    void SetOrthographicSize () {
        vCam.m_Lens.OrthographicSize = PixelPerfectResizer.orthographicSize;
    }
}