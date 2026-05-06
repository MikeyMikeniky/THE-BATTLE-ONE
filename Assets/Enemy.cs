using UnityEngine;

public class Enemy : Entity
{
    public bool playerDetected;


    [Header("Speed Atribuites")]
    [SerializeField] private float runSpeed = 5f;

    [SerializeField] private int Health = 10;




    protected override void Update()
    {
        base.Update();
        Attack();
    }

    protected override void Attack()
    {
        if(playerDetected)
        {

            Anim.SetTrigger("attack");
        }

    }

    protected override void HandleMovments()
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