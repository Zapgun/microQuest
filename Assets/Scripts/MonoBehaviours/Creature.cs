using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CreatureState {
    Idle, Stunned, Moving, Attacking, Dead
}

public class Creature : MonoBehaviour {
    
    public Rigidbody2D rb;
    public Animator anim;
    public CreatureState state = CreatureState.Idle;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
}
