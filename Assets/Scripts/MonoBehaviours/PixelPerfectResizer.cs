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

	public static float orthographicSize {
		get {
			float sf = Mathf.Max(Mathf.Ceil (Mathf.Pow (Screen.height, 0.5f) / 16f),1f);
			return (Screen.height / (sf * 16f)) * 0.5f;}
	}

	void Update() {
		orthoSize = orthographicSize;
	}
}