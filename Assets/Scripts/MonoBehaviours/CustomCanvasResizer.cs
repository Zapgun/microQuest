using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class CustomCanvasResizer : MonoBehaviour {

	float oldScaleFactor;
	public float scaleFactor;
	public float threshold = 300f;
	float numPixels;
	float screenHeight;
	public float pixelToUnits = 1f;
	public int gameMultiplier = 1;
	public static float orthographicSize;

	void Awake(){

		screenHeight = Screen.height;
		SetOrthographicSize();

	}

	// Update is called once per frame
	void Update () {

		float tmp = Screen.height * Screen.width;
		if (numPixels != tmp) {
			numPixels = tmp;
			//scaleFactor = Mathf.Max(Mathf.Ceil (Mathf.Pow (numPixels, 0.5f) / threshold),1f);
			scaleFactor = Mathf.Max(Mathf.Pow (numPixels, 0.5f) / threshold);
		}

		if (oldScaleFactor != scaleFactor) {
			GetComponent<CanvasScaler> ().scaleFactor = scaleFactor;
		}

		if (Screen.height != screenHeight || oldScaleFactor != scaleFactor) {
			screenHeight = Screen.height;
			SetOrthographicSize();
		}

		oldScaleFactor = scaleFactor;
	}

	void SetOrthographicSize() {

		orthographicSize = (screenHeight / 2.0f) / (pixelToUnits * scaleFactor * gameMultiplier);
		var camera = Camera.main;

		Cinemachine.CinemachineBrain brain = camera.GetComponent<Cinemachine.CinemachineBrain>();

		if (camera.orthographic && brain == null) { // Disable local call if using Cinemachine
			camera.orthographicSize = orthographicSize;
		}

	}
}
