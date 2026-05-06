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
    protected bool canJump = true;


    protected int FaceDir = 1;
    protected int deathHeight = 15;


    [SerializeField] private int Health = 1;
    [SerializeField] private int CurrentHealth;
    private bool GotHit;


    [Header("Speed Atribuites")]
    public float runSpeed = 5f;
    public float jumpForce = 3f;

    [Header("Colision detectioin")]
    private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask WhatIsGround;

    public Collider2D[] enemyColiders;
    [Header("Attack Details")]
    [SerializeField] protected float attackRadius;
    [SerializeField] protected LayerMask WhatIsTarget;
    [SerializeField] protected Transform AttackPoint;







    protected void Awake()
    {
        rb = this.GetComponent <Rigidbody2D>();
        Anim = this.GetComponentInChildren <Animator>();
        col = this.GetComponent <Collider2D>();
        Health = CurrentHealth;
    }
    
    protected virtual void Update()
    {
        handeAnimation();
        handleflip();
        handleCoilisons();
        handleInput();

        //Jumping

        if (Input.GetButtonDown("Jump") && isGrounded == true && canJump)
        {
            Jump();
       

        }
        //Atacking
        if (Input.GetKeyDown(KeyCode.Mouse0) && isGrounded == true)
        {
            Attack();


        }
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

    protected void takeDamage()
    {
        Anim.enabled = false;
      col.enabled = false;

        rb.gravityScale = 12;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, deathHeight);

    }
    protected virtual void handleInput()
    {
        if (canMove)
        {
            //Running
            rb.linearVelocity = new Vector2(Input.GetAxisRaw("Horizontal") * runSpeed, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);

        }
       
    }

    public void EnableMoveandJump(bool enable)
    {
        canJump = enable;
        canMove = enable;
    }

    protected virtual void Attack()
    {

        Anim.SetTrigger("Attack");
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);

    }
    
    private void Jump()
    {

        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

    }


    [ContextMenu("flip")]
    protected void handleflip()
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

    protected void flip()
    {

        transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
        FaceDir *= -1;
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -groundCheckDistance));
        Gizmos.DrawWireSphere(AttackPoint.position, attackRadius);
    }
    protected virtual void handleCoilisons()
    {

        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, WhatIsGround);
       
        
        enemyColiders = Physics2D.OverlapCircleAll(AttackPoint.position, attackRadius, WhatIsTarget);

    }

    protected  void handeAnimation()
    { 
        Anim.SetBool("isGrounded", isGrounded);
        Anim.SetFloat("Y velocity", rb.linearVelocity.y);
        Anim.SetFloat("X velocity", rb.linearVelocity.x);
    }


}


