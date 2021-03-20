using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility {

    /// <summary>
    /// This function returns a sub sprite from a sprite sheet saved 
    /// into the the resource folder.
    /// </summary>
    /// <param name="filePath">Sprite sheet path/name in the resource folder</param>
    /// <param name="spriteName">Name of the sprite on that sprite sheet</param>
    /// <returns></returns>
    public static Sprite LoadSprite (string filePath, string spriteName) {
        if (!string.IsNullOrEmpty (filePath)) {
            Sprite[] all = Resources.LoadAll<Sprite> (filePath);

            foreach (var s in all) {
                if (s.name == spriteName) {
                    return s;
                }
            }
        } else {
            Debug.LogWarning("Unable to find sprite filePath.");
        }
        return null;
    }

    /// <summary>
    /// This function returns a sub sprite from a sprite sheet saved into the
    /// resource folder.
    /// </summary>
    /// <param name="filePath">Sprite sheet path/name in the resource folder</param>
    /// <param name="spriteName">
    /// Index of the sprite on said sprite sheet. Note that this assumes sprites are
    /// named using the default Unity sprite sheet naming setup. For example, if the
    /// sprite sheet is named 'portraits' the first sprite will be named 'portraits_0.'
    /// </param>
    /// <returns></returns>
    public static Sprite LoadSprite (string filePath, int index) {
        if (!string.IsNullOrEmpty (filePath)) {
            Sprite[] all = Resources.LoadAll<Sprite> (filePath);
            Debug.Log (all.Length + " sprites loaded.");

            foreach (var s in all) {
                var tmp = filePath.Split ('/');
                string spriteName = tmp[tmp.Length - 1] + "_" + index; // Get the last part of the file path
                //Debug.Log(spriteName);
                if (s.name == spriteName) {
                    return s;
                }
            }
        } else {
            Debug.LogWarning("Unable to find sprite filePath.");
        }
        return null;
    }
}