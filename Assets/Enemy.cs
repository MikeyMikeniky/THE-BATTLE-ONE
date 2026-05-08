using UnityEngine;

public class Enemy : Entity
{
    public bool playerDetected;


    [Header("Speed Atribuites")]
    public float runSpeed = 1;


    private void Start()
    {
   
            Health = 1;
        
    }

    protected override void Update()
    {
        base.Update();
        Attack();
    }



    protected override void handeAnimation()
    {
        Anim.SetFloat("X velocity", rb.linearVelocity.x);

    }
    protected override void Attack()
    {
        if(playerDetected)
        {

            Anim.SetTrigger("Attack");
        }

    }

    protected override void HandleMovments()
    {
        if (canMove)
        {
            //Running
            rb.linearVelocity = new Vector2(FaceDir * runSpeed, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);

        }

    }



    protected override void handleCoilisons()
    {
        
        playerDetected = Physics2D.OverlapCircle(AttackPoint.position, attackRadius, WhatIsTarget);


    }


   protected override void takeDamage()
    {

        base.takeDamage();

        if (Health <= 0)
        {
           
            UI.instance.AddKillCount();
        }
    }
}