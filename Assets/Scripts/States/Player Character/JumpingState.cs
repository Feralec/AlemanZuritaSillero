using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : CharacterStates
{
    private float h;
    private Rigidbody2D rb;
    private Animator anim;

    public JumpingState(PlayerController p) : base(p)
    {
        rb = player.GetComponent<Rigidbody2D>();
        anim = player.GetComponent<Animator>();
    }

    public override void CheckTransitions()
    {
        throw new System.NotImplementedException();
    }

    public override void Execute()
    {
        throw new System.NotImplementedException();
    }

    public override void FixedExecute()
    {
        throw new System.NotImplementedException();
    }
}
