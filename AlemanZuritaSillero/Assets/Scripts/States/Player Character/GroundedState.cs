using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedState : CharacterStates
{
    private float h;

    protected Rigidbody2D rb;
    protected Animator anim;

    public GroundedState(PlayerController p) : base(p)
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
        h = Input.GetAxis("Horizontal");
        anim.SetFloat("absSpeed", Mathf.Abs(h));
    }

    public override void FixedExecute()
    {
        throw new System.NotImplementedException();
    }
}
