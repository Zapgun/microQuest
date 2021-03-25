 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is responsible for handling player state and movement
/// </summary>
public class Player : Creature {
    public float speed;
    Vector3 change;

    public int voidCheckRoomId; // instanceID of room used by void triggers

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        Move();
    }

    void Move() {
        if (state == CreatureState.Stunned)
            return;
        if (change != Vector3.zero) {
            change = Vector3.Normalize(change);
            anim.SetFloat("moveX", change.x);
            anim.SetFloat("moveY", change.y);
            anim.SetBool("moving", true);
           rb.MovePosition(transform.position + change * speed);
        } else {
            anim.SetBool("moving", false);
        }
    }
}