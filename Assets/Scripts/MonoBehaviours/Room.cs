using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// This class watching for colliders entering or exiting the room polygon collider
/// and reacts to a number of events:
/// - When a player enters / exits a room, its virtual camera is enabled/diabled
/// - When a player's void triggers enters/exits a room, it verifies the presence
///   of the next room and bounces the player back if it is missing.
/// </summary>
public class Room : MonoBehaviour {
    Cinemachine.CinemachineVirtualCamera[] vCam = null;

    void Awake () {
        vCam = GetComponentsInChildren<Cinemachine.CinemachineVirtualCamera> (true);
        Assert.IsNotNull (vCam);
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag ("Player")) {
            vCam[0].gameObject.SetActive (true);
            PlayerData.currentRoom = this.gameObject.name;
        } else if (other.CompareTag ("VoidTrigger")) {
            other.transform.parent.GetComponent<Player> ().voidCheckRoomId = gameObject.GetInstanceID ();
        }
    }

    void OnTriggerExit2D (Collider2D other) {
        if (other.CompareTag ("VoidTrigger")) {
            Player player = other.transform.parent.GetComponent<Player> ();

            // If the instanceId stays the same, we did not enter a new room
            if (player.voidCheckRoomId == gameObject.GetInstanceID ()) { 
                Debug.Log ("Void triggered!");

                // Create a negative force clamped at +/- 1
                Vector2 force = 10 * new Vector2 (-Mathf.Clamp (other.offset.x * 10, -1, 1), -1f * Mathf.Clamp (other.offset.y * 10, -1, 1));
                StartCoroutine (Utility.CreatureBounceCo (other.transform.parent, force));
            }
        } else if (other.CompareTag ("Player")) {
            vCam[0].gameObject.SetActive (false);
        }
    }
}