using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// This class will resize the orthographic view of the main camera, virtual cameras, and canvas
/// to try and keep pixel perfect viewing within the game.
/// See this post for details: https://blogs.unity3d.com/2015/06/19/pixel-perfect-2d
/// Formula:  Orthographic size = ((Vert Resolution)/(PPUScale * PPU)) * 0.5
/// </summary>
[ExecuteInEditMode]
public class PixelPerfectResizer : MonoBehaviour {

	[ReadOnly]
	public float orthoSize;
	int oldScreenHeight;

	public static float orthographicSize {
		get {
			int pixelsPerUnit = 16;
			float scaleFactor = Mathf.Max(Mathf.Ceil (Mathf.Pow (Mathf.Min(Screen.height, Screen.width), 0.5f) / 10f),1f);
			Debug.Log(scaleFactor);
			return (Screen.height / (scaleFactor * pixelsPerUnit)) * 0.5f;}
	}

	void Update() {

		if (Screen.height != oldScreenHeight)
		{
				orthoSize = orthographicSize;
				oldScreenHeight = Screen.height;
		}
	}
}