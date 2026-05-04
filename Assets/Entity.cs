using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Entity : MonoBehaviour
{

    protected Rigidbody2D rb;
    protected Animator Anim;

    protected bool facingRight = true;
    protected bool canMove = true;
    protected bool canJump = true;





    [Header("Speed Atribuites")]
    public float runSpeed = 5f;
    public float jumpForce = 3f;

    [Header("Colision detectioin")]
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask WhatIsGround;

    public Collider2D[] enemyColiders;
    [Header("Attack Details")]
    [SerializeField] private float attackRadius;
    [SerializeField] private LayerMask WhatIsTarget;
    [SerializeField] private Transform AttackPoint;







    protected void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Anim = this.GetComponentInChildren<Animator>();
        
    }
    
    protected virtual void Update()
    {
        handeAnimation();
        handleflip();
        handleCoilisons();
        handleInput();
    }

    public void DamageTargets()
    {

        enemyColiders = Physics2D.OverlapCircleAll(AttackPoint.position, attackRadius, WhatIsTarget);



        foreach (Collider2D enemy in enemyColiders)
        {

            Entity EntityTarget = enemy.GetComponent<Entity>();
            EntityTarget.takeDamage();

        }
    }

    private void takeDamage()
    {



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
    private void handleflip()
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

    private void flip()
    {

        transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -groundCheckDistance));
        Gizmos.DrawWireSphere(AttackPoint.position, attackRadius);
    }
    protected virtual void handleCoilisons()
    {

        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, WhatIsGround);

    }

    private void handeAnimation()
    { 
        Anim.SetBool("isGrounded", isGrounded);
        Anim.SetFloat("Y velocity", rb.linearVelocity.y);
        Anim.SetFloat("X velocity", rb.linearVelocity.x);
    }


}


