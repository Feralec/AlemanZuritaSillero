using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedState : CharacterStates
{
    protected float h; //los hago protected por si el shooting state lo hereda, si es que hago shooting state
    protected Rigidbody2D rb; 
    protected Animator anim;
    protected SpriteRenderer spr;

    public GroundedState(PlayerController p) : base(p)
    {
        rb = player.GetComponent<Rigidbody2D>();
        anim = player.GetComponent<Animator>();
        spr = player.GetComponent<SpriteRenderer>();
    }

    public override void OnStart()
    {
        anim.SetBool("isJumping", false);
    }
    public override void OnFinish()
    {
        base.OnFinish();
    }

    public override void CheckTransitions()
    {
        RaycastHit2D[] hitResults = new RaycastHit2D[2];
        if (rb.Cast(new Vector2(0, -1), hitResults, 0.1f) == 0)
            player.ChangeState(new JumpingState(player));
    }

    public override void Execute()
    {
        h = Input.GetAxis("Horizontal");
        anim.SetFloat("absSpeed", Mathf.Abs(h));

        if (Input.GetButtonDown("Jump"))
            rb.AddForce(new Vector2(0, player.jumpImpulse), ForceMode2D.Impulse); //de nuevo, cambiaremos esto con el datamodel

        if (h < 0)
            spr.flipX = true;
        else if (h > 0)
            spr.flipX = false;
            
    }

    public override void FixedExecute()
    {
        rb.velocity = new Vector2(h * player.horizontalSpeed, rb.velocity.y); //luego le meteremos datamodel
    }


}
