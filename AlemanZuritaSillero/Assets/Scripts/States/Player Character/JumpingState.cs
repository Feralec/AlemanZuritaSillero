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
    public override void OnStart()
    {
        anim.SetBool("isJumping", true);
    }
    public override void OnFinish()
    {
        base.OnFinish();
    }

    public override void CheckTransitions()
    {
        RaycastHit2D[] hitResults = new RaycastHit2D[2];
        if (rb.Cast(new Vector2(0, -1), hitResults, 0.1f) > 0)
            player.ChangeState(new GroundedState(player));
    }

    public override void Execute()
    {
        h = Input.GetAxis("Horizontal");

    }

    public override void FixedExecute()
    {
        rb.velocity = new Vector2(h * player.pm.horizontalSpeed*player.pm.jumpingHorizontalLimiter, rb.velocity.y);
    }
}
