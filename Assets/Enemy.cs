using UnityEngine;

public class Enemy : Entity
{
    public bool playerDetected;

    private Respawning resp;

    [Header("Speed Atribuites")]
    public float runSpeed = 1;

    private void Start()
    {
        resp = FindFirstObjectByType<Respawning>();

        Health = 1;

        if (Time.time > 30)
        {
            if (resp != null)
            {
                resp.cooldown = 1.5f;
            }

            Health = 2;
        }

        if (Time.time > 60)
        {
            Damage = 2;
        }

        if (Time.time > 90)
        {
            if (resp != null)
            {
                resp.cooldown = 1f;
            }
        }

        if (Time.time > 120)
        {
            if (resp != null)
            {
                resp.cooldown = 0.01f;
            }
        }
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