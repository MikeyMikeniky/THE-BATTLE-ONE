using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Entity : MonoBehaviour
{

    protected Rigidbody2D rb;
    protected Animator Anim;
    protected Collider2D col;
    protected bool facingRight = true;
   
    
    protected bool canMove = true;



    protected int FaceDir = 1;
    protected int deathHeight = 15;
    protected int Damage = 1;

    protected int CurrentHealth;
    public int Health = 100;
    private bool GotHit;

  

    [Header("Colision detectioin")]
    protected bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask WhatIsGround;

    public Collider2D[] enemyColiders;
    [Header("Attack Details")]
    [SerializeField] protected float attackRadius;
    [SerializeField] protected LayerMask WhatIsTarget;
    [SerializeField] protected Transform AttackPoint;

    protected virtual void Awake()
    {
        rb = this.GetComponent <Rigidbody2D>();
        Anim = this.GetComponentInChildren <Animator>();
        col = this.GetComponent <Collider2D>();
        CurrentHealth = Health;
    }
    
    protected virtual void Update()
    {
        handeAnimation();
        handleflip();
        handleCoilisons();
        HandleMovments();
    }

    public virtual void DamageTargets()
    {

        Collider2D[] enemyColiders = Physics2D.OverlapCircleAll(AttackPoint.position, attackRadius, WhatIsTarget);

        foreach (Collider2D enemy in enemyColiders)
        {

            Entity EntityTarget = enemy.GetComponent<Entity>();
            EntityTarget.takeDamage();

        }
    }

    protected virtual void takeDamage()
    {
        Health = Health - Damage;

        if (Health == 0)
        {
            rb.gravityScale = 12;
            rb.linearVelocity = new Vector2(0, deathHeight);
            Anim.enabled = false;
            col.enabled = false;

            Destroy(gameObject, 3);

        }
    }


    protected virtual void HandleMovments()
    {
    }
   

    public virtual void EnableMoveandJump(bool enable)
    {
        canMove = enable;
    }

    protected virtual void Attack()
    {

        Anim.SetTrigger("Attack");
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);

    }
    


    [ContextMenu("flip")]
    protected virtual void handleflip()
    {

        if (rb.linearVelocity.x > 0 && facingRight == false)
        {
            flip();
        }
       
        if (rb.linearVelocity.x < 0 && facingRight == true) 
        {
            flip();
        }
    }

    public void flip()
    {

        transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
        FaceDir *= -1;
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -groundCheckDistance));

        if (AttackPoint != null)
        {
            Gizmos.DrawWireSphere(AttackPoint.position, attackRadius);
        }
      
    }
    protected virtual void handleCoilisons()
    {

        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, WhatIsGround);
       
        
        enemyColiders = Physics2D.OverlapCircleAll(AttackPoint.position, attackRadius, WhatIsTarget);

    }

    protected virtual void handeAnimation()
    { 
        Anim.SetBool("isGrounded", isGrounded);
        Anim.SetFloat("Y velocity", rb.linearVelocity.y);
        Anim.SetFloat("X velocity", rb.linearVelocity.x);
    }


}


