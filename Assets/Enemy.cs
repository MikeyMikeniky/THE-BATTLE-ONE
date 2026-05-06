using UnityEngine;

public class Enemy : Entity
{


    public bool playerDetected;
   
        
        
        protected override void Update()
    {
        
        handleflip();
        handleCoilisons();
        handleInput();
        handeAnimation();
        Attack();
    }

    protected override void Attack()
    {
        if(playerDetected)
        {

            Anim.SetTrigger("attack");
        }

    }

    protected override void handleInput()
    {
        if (canMove)
        {
            //Running
            rb.linearVelocity = new Vector2(FaceDir, rb.linearVelocity.y);
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
}