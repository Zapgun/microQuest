using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoItem : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        var dist = Vector2.Distance(transform.position, other.transform.position);

        if (dist > 3.0f) {
            animator.SetBool("visible", true);
        } else {
            animator.SetBool("detailed", true);
        }
    }

    /// <summary>
    /// Sent when another object leaves a trigger collider attached to
    /// this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerExit2D(Collider2D other)
    {
        var dist = Vector2.Distance(transform.position, other.transform.position);

        if (dist < 3.0f) {
            animator.SetBool("visible", false);
        } else {
            animator.SetBool("detailed", false);
        }        
    }
}
